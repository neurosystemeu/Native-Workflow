using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestWorkflow.Processes
{
    public class ConsoleProcess : NeuroSystem.Workflow.Core.Process.ProcessWithUI.Console.ConsoleProcessBase
    {
        public string Name { get; set; }
        public string Age { get; set; }

        public override object Start()
        {
            WriteLine("Enter name");
            Name = ReadLine();

            WriteLine("Enter age");
            Age = ReadLine();

            return "Hello " + Name + " " + Age;
        }
    }
}
