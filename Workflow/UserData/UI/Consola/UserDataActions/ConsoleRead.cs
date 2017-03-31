namespace NeuroSystem.Workflow.UserData.UI.Consola.UserDataActions
{
    public class ConsoleRead : UserDataBase
    {
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
