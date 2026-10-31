using System;
using System.IO;

namespace NghiepVu.TienIch
{
    public static class NhatKyLoi
    {
        private static readonly object _lockObj = new object();
        private static string _duongDanTepLog;

        static NhatKyLoi()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                _duongDanTepLog = Path.Combine(baseDir, "log.txt");
            }
            catch
            {
                _duongDanTepLog = "log.txt";
            }
        }

        public static void GhiLog(string tieuDe, Exception ex)
        {
            try
            {
                lock (_lockObj)
                {
                    string noiDung = string.Format(
                        "[{0:yyyy-MM-dd HH:mm:ss}] [ERROR] {1}{2}Exception: {3}{2}StackTrace: {4}{2}--------------------------------------------------{2}",
                        DateTime.Now,
                        tieuDe,
                        Environment.NewLine,
                        ex?.Message,
                        ex?.StackTrace
                    );

                    File.AppendAllText(_duongDanTepLog, noiDung);
                }
            }
            catch
            {
                // Tránh throw exception từ logger
            }
        }

        public static void GhiLog(string thongDiep)
        {
            try
            {
                lock (_lockObj)
                {
                    string noiDung = string.Format(
                        "[{0:yyyy-MM-dd HH:mm:ss}] [INFO] {1}{2}",
                        DateTime.Now,
                        thongDiep,
                        Environment.NewLine
                    );

                    File.AppendAllText(_duongDanTepLog, noiDung);
                }
            }
            catch { }
        }
    }
}

