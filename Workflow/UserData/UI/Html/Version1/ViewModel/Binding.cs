using NeuroSystem.Workflow.Core.Extensions;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.ViewModel
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
            var strBinding = binding as Binding;

            if (strBinding != null )
            {
                //mamy bindowanie
                if (dataContext == null)
                {
                    return null;
                }
                
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

        public override string ToString()
        {
            return Path;
        }
    }
}
