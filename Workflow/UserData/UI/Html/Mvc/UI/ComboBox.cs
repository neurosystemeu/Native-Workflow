using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public class ComboBox : DropDownListBase
    {
        private readonly static Regex EscapeRegex;

        public ComboBox()
        {
            DataSource = new DataSource();
        }

        public bool? AutoBind
        {
            get;
            set;
        }

        public string CascadeFrom
        {
            get;
            set;
        }

        public string CascadeFromField
        {
            get;
            set;
        }

        public string DataValueField
        {
            get;
            set;
        }

        public bool? HighlightFirst
        {
            get;
            set;
        }

        public string Placeholder
        {
            get;
            set;
        }

        public int? SelectedIndex
        {
            get;
            set;
        }

        public bool? Suggest
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        static ComboBox()
        {
            
            ComboBox.EscapeRegex = new Regex("([;&,\\.\\+\\*~'\\:\\\"\\!\\^\\$\\[\\]\\(\\)\\|\\/])", RegexOptions.Compiled);
        }

    }
}
