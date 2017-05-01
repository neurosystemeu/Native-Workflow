using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.DataAnnotations
{
    /// <summary>
    /// Opis widoczności propercji na liście
    /// Dużej - czyli przy generowaniu listy
    /// Małej - czyli przy generowaniu dataformy i w przypadku gdy w modelu mamy listę danego typu
    /// </summary>
    public enum EnumGridColumnVisibleMode
    {
        BigList,
        SmallList,
        SmallAndBigList
    }
}
