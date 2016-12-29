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

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var view = new ViewFactory<TestObject>();
            view.DataForms(forms =>
            {
                forms.Pole(pp => pp.Age);

                forms.DodajDataForm(p =>
                {
                    p.Pole(pp => pp.Name);
                    p.Pole(pp => pp.Age);
                    p.Width("50%").Height("50px");
                });
                forms.DodajDataForm(p =>
                {
                    p.Pole(pp => pp.Age).Height("400px").Width("50%");
                });
                forms.GridView(k =>
                {
                    k.Column(p => p.Name);
                    k.Column(p => p.Age);
                });
            });
        }
    }
}
