using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData;

namespace NeuroSystem.Workflow.UI.Consola
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
