using System;
using System.Diagnostics;
using System.IO;

namespace miensol.RunMe
{
    public class RakeCommand : ICommandToRun
    {
        public const string RUBY_EXE = @"C:\Users\piotr_000\progi\Ruby200\bin\ruby.exe";
        private static readonly string Rake = Path.Combine(Path.GetDirectoryName(RakeCommand.RUBY_EXE), "rake");


        private readonly string _workingDir;
        private readonly string _task;
        private readonly string _description;

        public RakeCommand(string workingDir, string task, string description)
        {
            _workingDir = workingDir;
            _task = task;
            _description = description;
        }

        public string Name { get { return _task; } }
        public string Description { get { return _description; } }
        
        public ProcessStartInfo CreateProcessStartInfo()
        {
            return CreateProcessStartInfo(_workingDir, string.Format("{0} {1}", Rake, Name));
        }

        public static ProcessStartInfo ListRakeCommandsInStartInfo(string workingDir)
        {
            string arguments = string.Format("{0} -T -A", Rake);
            return CreateProcessStartInfo(workingDir, arguments);
        }

        private static ProcessStartInfo CreateProcessStartInfo(string workingDir, string arguments)
        {
            return new ProcessStartInfo(RUBY_EXE, arguments)
            {
                WorkingDirectory = workingDir,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
        }
    }
}