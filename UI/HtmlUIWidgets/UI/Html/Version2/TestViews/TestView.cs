using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Builders;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.TestViews
{
    public class TestView
    {
        public Panel GetView()
        {
            var html = new WidgetFactory();
            var ac = html.AutoComplete()
                .DataSource(source =>
                    source.Read(a => a.ToString())
                );
            var panel = html.Panel().Class("form-group");
            panel.HtmlAttributes("style", "height:400px; width:400px; background-color:red;");
            panel.Items(panels =>
            {
                panels.Class("p1");
            });
            panel.Items(panels =>
            {
                panels.Class("p2");
            });
            return panel.ToComponent();
        }
    }
}
