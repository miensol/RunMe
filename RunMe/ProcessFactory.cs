using System.Diagnostics;

namespace miensol.RunMe
{
    public class ProcessFactory
    {
        public static ProcessStartInfo Create(string command, string arguments, string workingDir = "c:/")
        {
            return new ProcessStartInfo(command, arguments)
                {
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = workingDir,
                };
        }
    }
}