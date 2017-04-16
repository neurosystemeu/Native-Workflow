using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public class DatePickerBase : WidgetBase
    {
        public string Format
        {
            get;
            set;
        }

        public DateTime Max
        {
            get;
            set;
        }

        public DateTime Min
        {
            get;
            set;
        }

        public List<string> ParseFormats
        {
            get;
            set;
        }

        public DateTime? Value
        {
            get;
            set;
        }

        public DatePickerBase() 
        {
            this.ParseFormats = new List<string>();
            //this.Animation = new PopupAnimation();
            //this.Dates = new List<DateTime>();
            this.Value = null;
            //this.Enabled = true;
        }
    }
}
