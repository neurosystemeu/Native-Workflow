namespace UnitTestWorkflow.Processes.UI
{
    public class ConsoleProcess : NeuroSystem.Workflow.Core.Process.ProcessWithUI.Console.ConsoleProcessBase
    {
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
