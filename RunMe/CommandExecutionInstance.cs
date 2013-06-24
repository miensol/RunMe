using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;

namespace miensol.RunMe
{
    public class CommandExecutionInstance
    {
        private readonly ICommandToRun _command;


        public CommandExecutionInstance(ICommandToRun command, Guid id)
        {
            Id = id;
            _command = command;
            TextOutputer = s => { };
            OutputChanged += OutputMessage;
        }

        private void OutputMessage()
        {
            string output;
            if (_outputs.TryDequeue(out output))
            {

                TextOutputer(output);
            }
        }

        public void Start()
        {
            var processStart = _command.CreateProcessStartInfo();
            PushOutput(processStart.FileName + " " + processStart.Arguments);
            _process = new Process {StartInfo = processStart, EnableRaisingEvents = true};
            _process.Exited += (sender, args) => PushOutput("Process exited with code: " + _process.ExitCode);
            _process.OutputDataReceived += (sender, args) => PushOutput(args.Data);
            _process.ErrorDataReceived += (sender, args) => PushOutput(args.Data);
            _process.Start();
            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();
        }

        private void PushOutput(string text)
        {
            if (text == null)
            {
                return;
            }
            if (text.EndsWith(Environment.NewLine) == false)
            {
                text += Environment.NewLine;
            }
            _outputs.Enqueue(text);
            OutputChanged();
        }

        public Guid Id { get; set; }

        public Action<string> TextOutputer { get; set; }

        private readonly ConcurrentQueue<string> _outputs = new ConcurrentQueue<string>();
        private Process _process;

        private event Action OutputChanged;

        public void WaitUntilDone()
        {
            _process.WaitForExit();
        }
    }
}