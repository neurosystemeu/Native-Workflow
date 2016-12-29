using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.DataSources
{
    /// <summary>
    /// Obiekt reprezentujący zródło danych
    /// </summary>
    public class DataSourceBase
    {
        /// <summary>
        /// Zwraca wszystekie dane
        /// </summary>
        /// <param name="filtr"></param>
        /// <returns></returns>
        public virtual object GetAll(string filtr = null)
        {
            throw new NotImplementedException();
        }

        public virtual object GetObjectById(string id)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(object objectToSave)
        {
            throw new NotImplementedException();
        }

        public virtual void Add(object objectToAdd)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
