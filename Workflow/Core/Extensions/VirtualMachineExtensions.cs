using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.Core.Process;

namespace NeuroSystem.Workflow.Core.Extensions
{
    public static class VirtualMachineExtensions
    {
        public static ProcessBase GetProcess(this VirtualMachine.VirtualMachine virtualMachine)
        {
            return virtualMachine.Instance as ProcessBase;
        }
    }
}
