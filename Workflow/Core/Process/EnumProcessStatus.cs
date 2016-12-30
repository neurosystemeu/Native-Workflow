using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.Core.Process
{
    public enum EnumProcessStatus
    {
        WaitingForExecution,
        Running,
        WaitingForUserData,
        Executed,
        Error
    }
}
