using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuroSystem.Workflow.Engine;
using NeuroSystem.Workflow.Engine.DAL;
using NeuroSystem.Workflow.UserData.UI.Html.UserDataActions;

namespace UnitTestWorkflow.Processes.UI.BW
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var processId = Guid.NewGuid();
            var newProcess = new ZapiszMailaJakoDokumentacjeProces() { Id = processId };
            newProcess.Dane = new DaneZapiszMailaJakoFokumentacje();
            var dal = new WorkflowEngineDAL();
            var engine = new WorkflowEngine(dal);

            engine.AddProcess(newProcess);
            engine.RunOneIteration();
            //wyśweitlenie formati i wprowadzenie danych 
            var process = engine.GetProcess(processId);
            engine.SetUserData(process.Id , new HtmlRead() { ActionName = "Anuluj" });
            engine.RunOneIteration();
            process = engine.GetProcess(processId);

            Assert.AreEqual("Anulowano proces", process.ProcesOutput);
        }
    }
}
