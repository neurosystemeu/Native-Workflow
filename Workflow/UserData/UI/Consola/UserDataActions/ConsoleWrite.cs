﻿namespace NeuroSystem.Workflow.UserData.UI.Consola.UserDataActions
{
    public class ConsoleWrite : UserDataBase
    {
        public string Text { get; set; }
        public bool NewLine { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
