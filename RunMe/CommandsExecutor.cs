using System;
using System.Collections.Generic;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

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
}