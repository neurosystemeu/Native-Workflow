using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.Core.Process;
using NeuroSystem.Workflow.Core.Process.ProcessWithUI.Console;

namespace UnitTestWorkflow.Processes
{
    public class HelloWorldProcess : ProcessBase
    {
        public override object Start()
        {
            return "Hello World";
        }
    }
}
