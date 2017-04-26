using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Infrastructure
{
    /// <summary>
    /// Interfejs przekazujący potrzebne dane do generowania widoku
    /// </summary>
    public interface IViewGeneratorHelper
    {
        string GetObjectName(Type repositoryType, string idObiektu);
    }
}
