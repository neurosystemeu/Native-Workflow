using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.ViewModel
{
    public class Binding
    {
        public Binding()
        {
            
        }

        public Binding(string path)
        {
            Path = path;
        }

        public string Path { get; set; }
    }
}
