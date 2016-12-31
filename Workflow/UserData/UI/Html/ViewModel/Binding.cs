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

        public static void UstawWartosc<T>(ref T binding, object dataContext, T wartosc)
        {
            if (binding == null)
            {
                return;
            }

            var strBinding = binding as Binding;
            if (strBinding != null )
            {
                //mamy bindowanie
                var mw = dataContext;
                var path = strBinding.Path;

                mw.SetPropValue(path, wartosc);
            }
            else
            {
                //mamy obiekt bez bindowania - ustawiam jego wartośc
                binding = wartosc;
            }
        }
    }
}
