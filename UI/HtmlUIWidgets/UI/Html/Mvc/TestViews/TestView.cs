using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.TestViews
{
    public class TestView
    {
        public Panel GetView()
        {
            var model = new PracownikTest();
            model.Imie = "Jan";
            model.Nazwisko = "Kowalski";

            var html = new WidgetFactory();
            var ac = html.AutoComplete()
                .DataSource(source =>
                    source.Read(a => a.ToString())
                );
            var panel = html.Panel<PracownikTest>();
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
