﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets.DataForms
{
    public class NsLabel : Label
    {

        public static NsLabel CreateLabel(WidgetBase widget)
        {
            var l = new NsLabel();
            l.Text = widget.Label?.ToString();
            return l;
        }
    }
}
