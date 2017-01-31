using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NeuroSystem.VirtualMachine.Core;
using NeuroSystem.Workflow.Core;
using NeuroSystem.Workflow.Core.Extensions;
using NeuroSystem.Workflow.Core.Process;
using NeuroSystem.Workflow.Engine.DAL;
using NeuroSystem.Workflow.UserData.Actions;

namespace NeuroSystem.Workflow.Engine
{
    public class WorkflowEngine
    {
        public WorkflowEngine(WorkflowEngineDAL dal)
        {
            this.dal = dal;
        }

        #region Properties

        private WorkflowEngineDAL dal;
        private EnumWorkfloEngineState state;
        private Thread engineThread;

        #endregion

        #region Zarządzające

        public ProcessContainer AddProcess(ProcessBase process)
        {
            process.Status = EnumProcessStatus.WaitingForExecution;
            var wm = new VirtualMachine.VirtualMachine();
            //dodaje tylko do kolejki uruchomienia - nie uruchamiam w tym wątku
            wm.Start(process, doExecuting: false);
            var xml = wm.Serialize();

            var serializedProcess = new ProcessContainer();
            serializedProcess.Id = process.Id;
            serializedProcess.Status = process.Status;
            serializedProcess.ExecutionDate = process.ExecutionDate;
            serializedProcess.VirtualMachineXml = xml;

            dal.AddProcess(serializedProcess);
            return serializedProcess;
        }

        public EnumProcessStatus GetProcessStatus(Guid processId)
        {
            return dal.GetProcessStatus(processId);
        }

        public void SetUserData(Guid processId, object userData)
        {
            var ser = dal.GetSerializedProcess(processId);
            var vm = ser.GetVirtualMachine();
            var process = vm.GetProcess();
            process.UserDataInput = userData;
            process.Status = EnumProcessStatus.WaitingForExecution;
            ser.SetProcessData(process);
            ser.SetVirtualMachine(vm);
            dal.Update(ser);
        }

        public ProcessBase GetProcess(Guid processId)
        {
            var ser = dal.GetSerializedProcess(processId);
            var vm = ser.GetVirtualMachine();

            return vm.GetProcess();
        }

        #endregion

        #region Process Execution

        /// <summary>
        /// Uruchamia silnik procesów w osobnym wątku
        /// </summary>
        public void RunEngineAsync()
        {
            this.state = EnumWorkfloEngineState.Started;
            var engineThread = new Thread(executionThread);
            engineThread.Start(this);
        }

        /// <summary>
        /// Główny wątek silnika procesów - wykonuje w koło 
        /// </summary>
        private static void executionThread(object engine)
        {
            var workflowEngine = engine as WorkflowEngine;
            while (workflowEngine.state != EnumWorkfloEngineState.Stoped)
            {
                try
                {
                    workflowEngine.RunOneIteration();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        public void RunOneIteration()
        {
            // Procesy po timeout - Przechodzę procesy po timeout i wznawiam ich wykonywanie z informacją o timeout
            var procesyPoTimeout = dal.GetSerizlizedProcessesAfterTimeout();

            // Procesy do uruchomienia
            var procesyDoWznowienia = dal.GetSerializedProcessesToResume();

            // Procesy po timeout - Przechodzę procesy po timeout i wznawiam ich wykonywanie z informacją o timeout
            foreach (var processWithTimeout in procesyPoTimeout)
            {
                procesPoTimeout(processWithTimeout);
            }

            // Procesy do uruchomienia
            if (procesyDoWznowienia.Any() == false)
            {
                Thread.Sleep(1000);
            }
            else
            {
                //mamy procesy do wznowienia - uruchomienia
                foreach (var processToResume in procesyDoWznowienia)
                {
                    //ThreadPool.QueueUserWorkItem(a =>
                    //{
                    procesDoUruchomienia(processToResume);
                    //});
                }
            }
        }

        private void procesPoTimeout(ProcessContainer serializedProcess)
        {
            var vm = serializedProcess.GetVirtualMachine();
            var process = vm.GetProcess();
            process.UserDataInput = new UserData.Actions.Timeout();
            process.Status = EnumProcessStatus.WaitingForExecution;

            serializedProcess.SetProcessData(process);
            serializedProcess.SetVirtualMachine(vm);
            dal.Update(serializedProcess);
        }

        private void procesDoUruchomienia(ProcessContainer serializedProcess)
        {
            var vm = serializedProcess.GetVirtualMachine();
            var process = vm.GetProcess();
            vm.Resume();

            if (vm.Status == VirtualMachineState.Exception)
            {
                process.Status = EnumProcessStatus.Error;
                process.StatusDescription = vm.RzuconyWyjatekWiadomosc;
            }
            else if (vm.Status == VirtualMachineState.Executed)
            {
                process.Status = EnumProcessStatus.Executed;
            }
            else if (vm.Status == VirtualMachineState.Hibernated)
            {
                if (process.UserDataOutput != null)
                {
                    //mamy dane od użytkownika -> oczekuje na dane od użytkownika
                    process.Status = EnumProcessStatus.WaitingForUserData;
                }
                else
                {
                    //wstrzymuje wykonanie
                    process.Status = EnumProcessStatus.WaitingForExecution;
                }
            }

            serializedProcess.SetProcessData(process);
            serializedProcess.VirtualMachineXml = vm.Serialize();

            dal.Update(serializedProcess);
        }

        #endregion

        public override string ToString()
        {
            return state.ToString();
        }

        public void StopEngine()
        {
            state = EnumWorkfloEngineState.Stoped;
        }
    }
}
