using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace miensol.RunMe
{
    public class RakeCommandSearcher
    {
        private readonly string _workingDir;

        public RakeCommandSearcher(string workingDir)
        {
            _workingDir = workingDir;
        }

        public IEnumerable<ICommandToRun> FindCommands()
        {

            var process = new Process
                {
                    StartInfo = RakeCommand.ListRakeCommandsInStartInfo(_workingDir)
                };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            return output.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                         .Select(line => line.Split('#'))
                         .Select(parts => new RakeCommand(_workingDir, parts[0].Replace("rake ", "").Trim(), parts.Last().Trim()));
        }
    }
}