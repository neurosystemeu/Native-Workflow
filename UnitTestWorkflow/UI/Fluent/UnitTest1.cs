using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent;

namespace UnitTestWorkflow.UI.Fluent
{
    public class TestObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Test2Object
    {
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mv = new TestObject();
            var mv2 = new Test2Object();

            var view = new ViewFactory<TestObject>();
            view.DataContext(mv);
            view.AddPanel(panel =>
            {
                panel.AddDataForm(p =>
                {
                    p.AddField(pp => pp.Name);
                    p.AddField(pp => pp.Age);
                    p.Width("50%").Height("50px");
                    p.AddComboBox()
                });
                panel.AddDataForm(p =>
                {
                    p.AddField(pp => pp.Age).Height("400px").Width("50%").WidthBinding("Szerokosc");
                    p.AddGridView(grid =>
                    {
                        grid.Column(k => k.Name);
                        grid.Column(k => k.Age).Width("100%");
                    });
                });
                panel.AddDataForm(mv2, p =>
                {
                    p.AddField(f => f.Imie);
                });
            });
        }
    }
}
