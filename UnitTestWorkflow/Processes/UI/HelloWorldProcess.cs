using NeuroSystem.Workflow.Core.Process;

namespace UnitTestWorkflow.Processes.UI
{
    public class HelloWorldProcess : ProcessBase
    {
        public override object Start()
        {
            return "Hello World";
        }
    }
}
