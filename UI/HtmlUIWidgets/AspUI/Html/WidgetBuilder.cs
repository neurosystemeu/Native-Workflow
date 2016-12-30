using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using NeuroSystem.UI.HtmlUIWidgets.AspUI.Html.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Views;
using NeuroSystem.Workflow.UserData.UI.Html.Widget;
using Telerik.Web.UI;
using Panel = NeuroSystem.Workflow.UserData.UI.Html.Widget.Panels.Panel;
using System.Web.UI;
using NeuroSystem.UI.HtmlUIWidgets.AspUI.Html.Widgets.Actions;
using NeuroSystem.UI.HtmlUIWidgets.AspUI.Html.Widgets.DataForm;
using NeuroSystem.Workflow.UserData.UI.Html.Widget.ItemsWidget;
using Action = NeuroSystem.Workflow.UserData.UI.Html.Widgets.Actions.Action;

namespace NeuroSystem.UI.HtmlUIWidgets.AspUI.Html
{
    public class WidgetBuilder
    {
        public void GenerateView(NsPanel panel, ViewBase view)
        {
            panel.Widget = view.Panel;
            GenerujElementy(view.Panel, panel);
        }

        public void GenerujElementy(WidgetBase widgetBase, NsPanel panelRodzic)
        {
            if (widgetBase is Action)
            {
                var akcja = widgetBase as Action;
                var a = UtworzAkcja(akcja);
                panelRodzic.Controls.Add(a);
            }
            else
            if (widgetBase is Panel)
            {
                var oPanel = widgetBase as Panel;
                var panel = UtworzPanel(oPanel);

                panelRodzic.Controls.Add(panel);
                foreach (var element in oPanel.Elementy)
                {
                    GenerujElementy(element, panel);
                }
            }
            //else if (pole is OpisTaby)
            //{
            //    GenerujTaby(pole as OpisTaby, panelRodzic);
            //}
            else
            {
                //mamy kontrolkę - generują ją
                if (widgetBase.Label != null)
                {
                    var label = UtworzLabel(widgetBase.Name);
                    label.Style["display"] = "block";
                    label.Width = new Unit("99%");
                    label.ToolTip = widgetBase.ToolTip;
                    panelRodzic.Controls.Add(label);
                }

                var kontrolka = GenerujKontrolke(widgetBase, panelRodzic);

                var kont = kontrolka as WebControl;
                if (kont != null)
                {
                    kont.Style["display"] = "block";
                    kont.Width = new Unit("99%");
                }

                panelRodzic.Controls.Add(kontrolka);
            }
        }

        #region Tworzenie elementu

        private RadLabel UtworzLabel(string p)
        {
            return new RadLabel() { Text = p };
        }

        public NsAction UtworzAkcja(WidgetBase opisAkcji)
        {
            var akcja = new NsAction() { Widget = opisAkcji, ToolTip = opisAkcji.ToolTip, Text = opisAkcji.GetReadableName() };

            //if (opisAkcji.UrlIkony != null)
            //{
            //    var ui = new MenadzerUI();
            //    akcja.Icon.PrimaryIconUrl = ui.Ikony.Pobierz(opisAkcji.UrlIkony, 16);
            //}

            return akcja;
        }

        protected Control GenerujKontrolke(WidgetBase widget, NsPanel panel)
        {
            //if (widget is ComboBox)
            //{
            //    return UtworzComboBox((OpisCombobox)widget);
            //}

            //if (widget is OpisDataICzas)
            //{
            //    return UtworzDateTimePicker((OpisDataICzas)widget);
            //}

            //if (widget is OpisCheckBox)
            //{
            //    return UtworzCheckBox(widget as OpisCheckBox);
            //}

            //if (widget is OpisAutoComplete)
            //{
            //    return UtworzAutoCompleteBox((OpisAutoComplete)widget);
            //}

            //if (widget is OpisCombobox)
            //{
            //    return UtworzComboBox((OpisCombobox)widget);
            //}

            //if (widget is OpisGrid)
            //{
            //    return UtworzGrid((OpisGrid)widget);
            //}

            //if (widget is OpisEdytora)
            //{
            //    return UtworzEdytor((OpisEdytora)widget);
            //}

            return UtworzTextBox(widget);
        }

        public NsTextBox UtworzTextBox(WidgetBase widget)
        {
            return NsTextBox.UtworzTextBox((NeuroSystem.Workflow.UserData.UI.Html.Widget.Simple.TextBox)widget);
        }

        public NsPanel UtworzPanel(Panel opisPola)
        {
            return NsPanel.UtworzPanel(opisPola);
        }

        #endregion
    }
}
