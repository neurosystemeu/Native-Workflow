using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.Core.Process;

namespace NeuroSystem.Workflow.Engine.DAL
{
    public class WorkflowEngineDAL
    {
        public WorkflowEngineDAL()
        {
            serializedProcesses = new Dictionary<Guid, ProcessContainer>();
        }

        private Dictionary<Guid, ProcessContainer> serializedProcesses;

        public virtual List<ProcessContainer> GetSerializedProcessesToResume()
        {
            var date = DateTime.Now;
            var list= this.serializedProcesses.Values.Where(p => p.Status == EnumProcessStatus.WaitingForExecution
                                        && (p.ExecutionDate == null || p.ExecutionDate <= date)).ToList();

            return list;
        }

        public virtual List<ProcessContainer> GetSerizlizedProcessesAfterTimeout()
        {
            var date = DateTime.Now;
            var list = serializedProcesses.Values.Where(p => p.Status == EnumProcessStatus.WaitingForUserData
                                        && p.ExecutionDate <= date).ToList();

            return list;
        }

        public virtual void Update(ProcessContainer process)
        {
            
        }

        public virtual void AddProcess(ProcessContainer process)
        {
            serializedProcesses[process.Id]=process;
        }

        public virtual EnumProcessStatus GetProcessStatus(Guid processId)
        {
            return serializedProcesses[processId].Status;
        }

        public virtual ProcessContainer GetSerializedProcess(Guid processId)
        {
            return serializedProcesses[processId];
        }
    }
}
