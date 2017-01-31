using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.VirtualMachine;
using NeuroSystem.Workflow.Core.Process;

namespace NeuroSystem.Workflow.Engine.DAL
{
    public class ProcessContainer
    {
        public ProcessContainer()
        {
        }

        public ProcessContainer(ProcessBase process)
        {
            SetProcessData(process);
        }

        public void SetProcessData(ProcessBase process)
        {
            Id = process.Id;
            Name = process.Name;
            Status = process.Status;
            ExecutionDate = process.ExecutionDate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public EnumProcessStatus Status { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public string VirtualMachineXml { get; set; }

        public VirtualMachine.VirtualMachine GetVirtualMachine()
        {
            return VirtualMachine.VirtualMachine.Deserialize(VirtualMachineXml);
        }

        public void SetVirtualMachine(VirtualMachine.VirtualMachine vm)
        {
            VirtualMachineXml = vm.Serialize();
        }
    }
}
