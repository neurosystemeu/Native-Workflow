using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NeuroSystem.VirtualMachine.Core.Attributes;

namespace NeuroSystem.Workflow.Core.Process
{
    /// <summary>
    /// Proces bazowy dla wirtualnej maszyny
    /// </summary>
    public class ProcessBase
    {
        #region Properties
        /// <summary>
        /// Id procesu
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Process Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Input parameter for process
        /// </summary>
        public object ProcesInput { get; set; }

        /// <summary>
        /// Process result
        /// </summary>
        public object ProcesOutput { get; set; }

        /// <summary>
        /// Process status
        /// </summary>
        public EnumProcessStatus Status { get; set; }

        public string StatusDescription { get; set; }

        /// <summary>
        /// Date of proces execution
        /// </summary>
        public DateTime? ExecutionDate { get; set; }

        /// <summary>
        /// Zmienna z wirtualną maszyną na której uruchomiony jest proces
        /// </summary>
        public VirtualMachine.VirtualMachine VirtualMachine;

        #region User data

        /// <summary>
        /// Dane użytkownika które wychodzą z procesu
        /// może to być jakiś opis widoku.
        /// Dane te obsługiwane są przez hosta wyświetlającego dane procesu
        /// </summary>
        public object UserDataOutput { get; set; }

        /// <summary>
        /// Dane użytkownika które przychodzą do procesu (z zewnątrz od użytkownika)
        /// </summary>
        public object UserDataInput { get; set; }

        #endregion

        /// <summary>
        /// Czy proces w trybie debug
        /// </summary>
        public bool Debug { get; set; }
        #endregion

        #region Method

        public virtual object Start()
        {
            return null;
        }

        public override string ToString()
        {
            return Status + " " + Id;
        }

        #endregion

        #region method for using in process

        [Interpret]
        public void Hibernate()
        {
            if (Debug == false)
            {
                NeuroSystem.VirtualMachine.VirtualMachine.Hibernate();
            }
            else
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    if (Status == EnumProcessStatus.Error ||
                        Status == EnumProcessStatus.Executed ||
                        Status == EnumProcessStatus.WaitingForExecution)
                    {
                        return;
                    }
                }
            }
        }

        [Interpret]
        public void Sleep(int iloscSekund)
        {
            Status = EnumProcessStatus.WaitingForExecution;
            ExecutionDate = DateTime.Now.AddSeconds(iloscSekund);
            NeuroSystem.VirtualMachine.VirtualMachine.Hibernate();
        }

        [Interpret]
        public void Sleep(DateTime dataUruchomienia)
        {
            Status = EnumProcessStatus.WaitingForExecution;
            ExecutionDate = dataUruchomienia;
            NeuroSystem.VirtualMachine.VirtualMachine.Hibernate();
        }

        [Interpret]
        public void EndProcess(object wynik = null)
        {
            Status = EnumProcessStatus.Executed;
            ProcesOutput = wynik;
            NeuroSystem.VirtualMachine.VirtualMachine.EndProcess();
        }

        #endregion
    }
}
