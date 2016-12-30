using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.Core.Extensions;

namespace NeuroSystem.Workflow.UserData.UI.Html.ViewModel
{
    public class Binding
    {
        public Binding()
        {
            
        }

        public Binding(string path)
        {
            Path = path;
        }

        public string Path { get; set; }

        public static object PobierzWartosc(object binding, object dataContext)
        {
            if (binding == null || dataContext == null)
            {
                return null;
            }

            var strBinding = binding as Binding;

            if (strBinding != null )
            {
                //mamy bindowanie
                var mw = dataContext;
                var path = strBinding.Path;
                var wartosc = mw.GetPropValue(path);
                return wartosc;
            }
            else
            {
                //mamy zwykły obiekt
                return binding;
            }
        }

        public static void UstawWartosc(object binding, object dataContext, object wartosc)
        {
            if (binding == null)
            {
                return;
            }

            var strBinding = binding as string;
            if (strBinding != null && strBinding.Contains("{Binding"))
            {
                //mamy bindowanie
                var mw = dataContext;
                var path = strBinding.Replace("{Binding ", "").Replace("Path=", "").Replace("}", "");

                mw.SetPropValue(path, wartosc);
            }
        }
    }
}
