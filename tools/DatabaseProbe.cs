using System;
using System.Data.SqlClient;
using System.Diagnostics;
using DuLieu;

// Read-only integration check for the same .NET Framework/data layer as the GUI.
internal static class DatabaseProbe
{
    private static void Check(string label)
    {
        using (var connection = KetNoiCSDL.LayKetNoi())
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "SELECT DB_NAME(), (SELECT COUNT(*) FROM sys.tables), " +
                "(SELECT COUNT(*) FROM dbo.NguoiDung), " +
                "(SELECT physical_name FROM sys.database_files WHERE file_id=1)";
            using (var reader = command.ExecuteReader())
            {
                reader.Read();
                Console.WriteLine("PASS {0}: Bitness={1}; Server={2}; Database={3}; Tables={4}; Users={5}; File={6}",
                    label, IntPtr.Size * 8, connection.DataSource, reader.GetString(0),
                    reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3));
            }
        }
    }

    private static int Main(string[] args)
    {
        try
        {
            Check("initial connection");
            if (args.Length == 2 && args[0] == "--restart-localdb")
            {
                SqlConnection.ClearAllPools();
                var start = new ProcessStartInfo(args[1], "stop MSSQLLocalDB")
                {
                    UseShellExecute = false, CreateNoWindow = true
                };
                using (var process = Process.Start(start))
                {
                    if (!process.WaitForExit(15000) || process.ExitCode != 0)
                        throw new InvalidOperationException("Could not stop LocalDB for the restart check.");
                }
                // Same process/data layer still caches the OLD pipe. This must reconnect automatically.
                Check("reconnect after LocalDB restart");
            }
            return 0;
        }
        catch (Exception error)
        {
            Console.Error.WriteLine("FAIL " + error);
            return 1;
        }
    }
}
