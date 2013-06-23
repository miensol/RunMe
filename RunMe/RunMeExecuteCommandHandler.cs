using System;
using System.ComponentModel.Design;
using System.IO;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace miensol.RunMe
{
    internal class RunMeExecuteCommandHandler
    {
        private DTE2 _dte;
        private TypeCommandWindow _dialog;
        private CommandsModel _commandsModel;
        private CachedCommands _cachedCommands;
        private CommandsExecutor _commandsExecutor;

        public CommandID CommandID
        {
            get { return new CommandID(Guids.guidRunMeCmdSet, PkgCmdIDs.idRunMeCmd); }
        }

        public RunMeExecuteCommandHandler()
        {
            _dte = VsServiceLocator.GetGlobalService<SDTE, DTE2>();

            _cachedCommands = new CachedCommands(GetPath());
            _commandsModel = new CommandsModel(_cachedCommands);
            _commandsExecutor = new CommandsExecutor(VsServiceLocator.GetGlobalService<SVsOutputWindow, IVsOutputWindow>(),
                VsServiceLocator.GetInstance<Package>(), _dte);
            
            _commandsModel.StartExecutingCommand += (cmd) => _dialog.Hide();
            _commandsModel.StartExecutingCommand += (cmd) => _commandsExecutor.StartExecuting(cmd);
        }

        public void Invoke(object sender, EventArgs e)
        {
            _dialog = new TypeCommandWindow
            {
                DataContext = _commandsModel
            };
            _dialog.Deactivated += (o, args) => _dialog.Hide();
            _dialog.Activated += (o, args) => _commandsModel.InitializeIfNeeded();
        
            _dialog.Show();
        }

        private string GetPath()
        {
            if (_dte.Solution != null && string.IsNullOrWhiteSpace(_dte.Solution.FullName) == false)
            {
                return Path.GetDirectoryName(_dte.Solution.FullName);
            }
            return Directory.GetCurrentDirectory();
        }
    }
}