using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using miensol.RunMe.Annotations;
using System.Linq;

namespace miensol.RunMe
{
    internal class CommandsModel : INotifyPropertyChanged
    {
        private readonly CachedCommands _cachedCommands;
        private bool _canSearch;
        private bool _initialized;
        private IEnumerable<ICommandToRun> _allCommands = new List<ICommandToRun>();
        private ObservableCollection<ICommandToRun> _filteredCommands = new ObservableCollection<ICommandToRun>();
        private string _findText;
        private ICommandToRun _commandToExecute;

        public CommandsModel(CachedCommands cachedCommands)
        {
            _cachedCommands = cachedCommands;
            CanSearch = cachedCommands.DidSearchForCommands;
        }

        public bool CanSearch
        {
            get { return _canSearch; }
            set
            {
                if (_canSearch != value)
                {
                    _canSearch = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InitializeIfNeeded()
        {
            if (!_initialized)
            {
                _allCommands = _cachedCommands.FindCommands();
                CanSearch = true;
                UpdateFilteredCommands();
                _initialized = true;
            }
        }

        private void UpdateFilteredCommands()
        {
            FilteredCommands = new ObservableCollection<ICommandToRun>(_allCommands);
        }

        public ObservableCollection<ICommandToRun> FilteredCommands
        {
            get { return _filteredCommands; }
            set
            {
                if (!_filteredCommands.Equals(value))
                {
                    _filteredCommands = value;
                    OnPropertyChanged();
                    CommandToExecute = _filteredCommands.FirstOrDefault();
                }
            }
        }

        public string FindText
        {
            get { return _findText; }
            set
            {
                if (_findText != value)
                {
                    _findText = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommandToRun CommandToExecute
        {
            get { return _commandToExecute; }
            set
            {
                if (_commandToExecute != value)
                {
                    _commandToExecute = value;
                    OnPropertyChanged();
                }
            }
        }

        public event Action<ICommandToRun> StartExecutingCommand;
 
        public void SetCommandToExecuteAndStart(ICommandToRun command)
        {
            CommandToExecute = command;
            RaiseStartExecutingCommand();
        }

        private void RaiseStartExecutingCommand()
        {
            if (StartExecutingCommand != null && CommandToExecute != null)
            {
                StartExecutingCommand(CommandToExecute);
            }
        }

        public void StartCommandIfEnter(Key key)
        {
            if (key == Key.Enter)
            {
                RaiseStartExecutingCommand();   
            }
        }
    }
}