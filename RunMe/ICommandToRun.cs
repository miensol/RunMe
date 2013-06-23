using System.Diagnostics;

namespace miensol.RunMe
{
    public interface ICommandToRun
    {
        string Name { get;  }
        string Description { get; }
        ProcessStartInfo CreateProcessStartInfo();
    }
}