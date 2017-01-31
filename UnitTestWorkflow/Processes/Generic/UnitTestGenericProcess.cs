using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuroSystem.Workflow.Core.Process.ProcessWithUI.Html;
using NeuroSystem.Workflow.Engine;
using NeuroSystem.Workflow.Engine.DAL;
using UnitTestWorkflow.TestObject;

namespace UnitTestWorkflow.Processes.Generic
{
    [TestClass]
    public class UnitTestGenericProcess
    {
        [TestMethod]
        public void TestMethodEditProcess()
        {
            var processId = Guid.NewGuid();
            var newProcess = new EditProcess<Person>(){ Id = processId };
            newProcess.ProcesInput = new Person();
            var dal = new WorkflowEngineDAL();
            var engine = new WorkflowEngine(dal);

            engine.AddProcess(newProcess);
            engine.RunOneIteration();
            var process = engine.GetProcess(processId);
        }

        [TestMethod]
        public void TestMethodListProcess()
        {
            var processId = Guid.NewGuid();
            var newProcess = new ListProcess<Person>() { Id = processId };
            var dal = new WorkflowEngineDAL();
            var engine = new WorkflowEngine(dal);

            engine.AddProcess(newProcess);
            engine.RunOneIteration();
            var process = engine.GetProcess(processId);
        }
    }
}
