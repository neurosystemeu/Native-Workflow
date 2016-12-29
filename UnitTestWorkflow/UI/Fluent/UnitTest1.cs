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
            view.Panels(panels =>
            {
                panels.Pole(pp => pp.Age);

                panels.DodajPanel(p =>
                {
                    p.Pole(pp => pp.Name);
                    p.Pole(pp => pp.Age);
                });
                panels.DodajPanel(p =>
                {
                    p.Pole(pp => pp.Age);
                });
            });
        }
    }
}
