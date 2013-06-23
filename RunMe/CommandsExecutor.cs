using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Process = System.Diagnostics.Process;

namespace miensol.RunMe
{
    public class CommandsExecutor
    {
        private readonly IVsOutputWindow _outputWindows;
        private readonly Package _package;
        private readonly DTE2 _dte2;

        public CommandsExecutor(IVsOutputWindow outputWindows, Package package, DTE2 dte2)
        {
            _outputWindows = outputWindows;
            _package = package;
            _dte2 = dte2;
        }

        public void StartExecuting(ICommandToRun command)
        {
            Guid id = Guid.NewGuid();
            _outputWindows.CreatePane(ref id, command.Name, Convert.ToInt32(true), Convert.ToInt32(true));
            IVsOutputWindowPane pane;
            _outputWindows.GetPane(ref id,out pane);
            var commandExecutionInstance = new CommandExecutionInstance(command, id);
            pane.Activate();
            var outputWindow = (OutputWindow)_dte2.ToolWindows.GetToolWindow("Output");
            outputWindow.Parent.SetFocus();
            commandExecutionInstance.TextOutputer = (text) => pane.OutputStringThreadSafe(text);
            commandExecutionInstance.Start();
        }
    }

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