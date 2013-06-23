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
            var process = new Process {StartInfo = processStart};
            process.Start();
            StartReadingOutput(process.StandardOutput);
            StartReadingOutput(process.StandardError);
        }

        private async void StartReadingOutput(StreamReader streamToReadFrom)
        {
            while (!streamToReadFrom.EndOfStream)
            {
                string line = await streamToReadFrom.ReadLineAsync();
                _outputs.Enqueue(line + Environment.NewLine);
                OutputChanged();
            }
        }

        public Guid Id { get; set; }

        public Action<string> TextOutputer { get; set; }

        private readonly ConcurrentQueue<string> _outputs = new ConcurrentQueue<string>();

        private event Action OutputChanged;
    }
}