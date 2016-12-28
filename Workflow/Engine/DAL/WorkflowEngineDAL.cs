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
            serializedProcesses = new Dictionary<Guid, SerializedProcess>();
        }

        private Dictionary<Guid, SerializedProcess> serializedProcesses;

        public virtual List<SerializedProcess> GetSerializedProcessesToResume()
        {
            var date = DateTime.Now;
            var list= this.serializedProcesses.Values.Where(p => p.Status == EnumProcessStatus.WaitingForExecution
                                        && (p.ExecutionDate == null || p.ExecutionDate <= date)).ToList();

            return list;
        }

        public virtual List<SerializedProcess> GetSerizlizedProcessesAfterTimeout()
        {
            var date = DateTime.Now;
            var list = serializedProcesses.Values.Where(p => p.Status == EnumProcessStatus.WaitingForUserData
                                        && p.ExecutionDate <= date).ToList();

            return list;
        }

        public void Update(SerializedProcess process)
        {
            
        }

        public void AddProcess(SerializedProcess process)
        {
            serializedProcesses[process.Id]=process;
        }

        public EnumProcessStatus GetProcessStatus(Guid processId)
        {
            return serializedProcesses[processId].Status;
        }

        public SerializedProcess GetSerializedProcess(Guid processId)
        {
            return serializedProcesses[processId];
        }
    }
}
