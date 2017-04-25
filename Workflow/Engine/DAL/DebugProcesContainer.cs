using System.Threading;
using NeuroSystem.Workflow.Core.Process;

namespace NeuroSystem.Workflow.Engine.DAL
{
    public class DebugProcesContainer : ProcessContainer
    {
        public ProcessBase Process { get; internal set; }
        public Thread Thread { get; internal set; }
    }
}
