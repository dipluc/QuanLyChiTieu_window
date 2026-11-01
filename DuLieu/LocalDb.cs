using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace DuLieu
{
    internal static class LocalDb
    {
        private static readonly object Sync = new object();
        private static readonly Dictionary<string, string> Pipes =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        internal static string LayDiaChi(string instance, bool refresh)
        {
            lock (Sync)
            {
                string pipe;
                if (!refresh && Pipes.TryGetValue(instance, out pipe)) return pipe;
                Pipes.Remove(instance);

                string executable = TimCongCu();
                string info = Chay(executable, "info", instance);
                string startInfo = string.Empty;
                pipe = DocPipe(info);
                if (pipe == null)
                {
                    startInfo = Chay(executable, "start", instance);
                    info = Chay(executable, "info", instance);
                    pipe = DocPipe(info);
                }
                if (pipe == null)
                    throw new InvalidOperationException("LocalDB không trả về địa chỉ kết nối. Tool=" + executable +
                        "; Start=" + startInfo + "; Info=" + info);

                Pipes[instance] = pipe;
                return pipe;
            }
        }

        private static string DocPipe(string info)
        {
            // Pipe thay đổi sau mỗi lần LocalDB khởi động; tuyệt đối không ghi cố định vào config.
            Match match = Regex.Match(info.Replace("\0", ""), @"np:\\\\[^\r\n]+", RegexOptions.IgnoreCase);
            return match.Success ? match.Value.Trim() : null;
        }

        private static string TimCongCu()
        {
            // Dùng đúng công cụ của bản LocalDB đã cài, không phụ thuộc PATH của debugger.
            using (RegistryKey machine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (RegistryKey versions = machine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions"))
            {
                if (versions != null)
                {
                    string[] names = versions.GetSubKeyNames();
                    Array.Sort(names, delegate(string a, string b)
                    {
                        Version av, bv;
                        return Version.TryParse(a, out av) && Version.TryParse(b, out bv)
                            ? bv.CompareTo(av) : StringComparer.OrdinalIgnoreCase.Compare(b, a);
                    });
                    foreach (string name in names)
                    using (RegistryKey version = versions.OpenSubKey(name))
                    {
                        if (version == null) continue;
                        string api = version.GetValue("InstanceAPIPath") as string;
                        if (string.IsNullOrWhiteSpace(api)) continue;
                        string tool = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(api),
                            @"..\..\Tools\Binn\SqlLocalDB.exe"));
                        if (File.Exists(tool)) return tool;
                    }
                }
            }
            throw new FileNotFoundException("Không tìm thấy công cụ SQL Server Express LocalDB. Hãy cài LocalDB trước khi chạy ứng dụng.");
        }

        private static string Chay(string executable, string operation, string instance)
        {
            if (instance.IndexOfAny(new[] { '"', '\r', '\n' }) >= 0)
                throw new ArgumentException("Tên instance LocalDB không hợp lệ.", "instance");
            var start = new ProcessStartInfo(executable, operation + " \"" + instance + "\"")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = Path.GetDirectoryName(executable)
            };
            using (Process process = Process.Start(start))
            {
                var output = process.StandardOutput.ReadToEndAsync();
                var error = process.StandardError.ReadToEndAsync();
                if (!process.WaitForExit(15000))
                {
                    process.Kill();
                    throw new TimeoutException("LocalDB không phản hồi trong 15 giây khi " + operation + " " + instance + ".");
                }
                string text = output.GetAwaiter().GetResult() + error.GetAwaiter().GetResult();
                if (process.ExitCode != 0)
                    throw new InvalidOperationException("Không thể " + operation + " LocalDB " + instance + ": " + text);
                return text;
            }
        }
    }
}
