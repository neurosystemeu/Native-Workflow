using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.Core.Process;
using NeuroSystem.Workflow.Core.Process.ProcessWithUI.Html;
using UnitTestWorkflow.TestObject;

namespace UnitTestWorkflow.Processes
{
    public class HtmlProcess :  HtmlProcessBase
    {
        public override object Start()
        {
            var view = CreateDataForm<Person>();
            view.DataForm(df =>
            {
                df.AddField(p => p.Name);
                df.AddField(p => p.Surname);
                df.AddField(p => p.Age);
                df.AddPanel(panel =>
                {
                    panel.AddAction("sdf");
                });
            });
            

            ShowView(view);


            return "OK";
        }
    }
}
