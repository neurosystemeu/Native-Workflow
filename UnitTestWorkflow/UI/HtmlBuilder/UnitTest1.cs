using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuroSystem.Workflow.UserData.UI.Html.Builders;

namespace UnitTestWorkflow.UI.HtmlBuilder
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var html = new WidgetFactory();
            var ac = html.AutoComplete()
                .DataSource(source=>
                    source.Read(a=>a.ToString())
                );
            var panel = html.Panel();
        }
    }
}
