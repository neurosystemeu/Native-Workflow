using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Builders;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.TestViews
{
    public class TestView
    {
        public Panel GetView()
        {
            var model = new PracownikTestModel();
            model.Imie = "Jan";
            model.Nazwisko = "Kowalski";

            var html = new WidgetFactory();
            var ac = html.AutoComplete()
                .DataSource(source =>
                    source.Read(a => a.ToString())
                );
            var panel = html.Panel<PracownikTestModel>();
            panel.HtmlAttributes("style", "height:400px; width:400px; background-color:red;");
            panel.AddItem(panels =>
            {
                panels.Class("p1");
            });
            panel.AddItem(panels =>
            {
                panels.Class("p2");
            });
            panel.Items(p =>
            {
                p.Add().AddItem(pp => pp.Class("p4")).Class("p3");
            });

            var tb = html.TextBox<string>();

            panel.AddItem(tb.ToComponent());
            return panel.ToComponent();
        }
    }
}
