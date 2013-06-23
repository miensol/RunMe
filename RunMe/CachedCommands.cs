using System.Collections.Generic;

namespace miensol.RunMe
{
    public class CachedCommands
    {
        private readonly string _workingDir;
        private RakeCommandSearcher _rakeCommandSearcher;

        public CachedCommands(string workingDir)
        {
            _workingDir = workingDir;
            _rakeCommandSearcher = new RakeCommandSearcher(workingDir);
        }

        public bool DidSearchForCommands { get; set; }

        public IEnumerable<ICommandToRun> FindCommands()
        {
            return _rakeCommandSearcher.FindCommands();
        }
    }
}