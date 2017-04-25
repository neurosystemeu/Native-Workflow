using System.Web.UI;
using System.Web.UI.WebControls;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Views;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Actions;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Panels;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Tabs;
using Telerik.Web.UI;
using Panel = NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Panels.Panel;
using Action = NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Actions.Action;
using CheckBox = NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms.CheckBox;
using GridView = NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets.GridView;
using Label = NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms.Label;
using TextBox = NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms.TextBox;
using TreeView = NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets.TreeView;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1
{
    public class WidgetBuilder
    {
        public void GenerateView(NsPanel panel, ViewBase view, IViewer viewer, bool isPostBack)
        {
            panel.Widget = view.Panel;
            GenerujElementy(view.Panel, panel, viewer, isPostBack);
        }

        protected void GenerujElementy(WidgetBase widgetBase, NsPanel panelRodzic, IViewer viewer, bool isPostBack)
        {
            if (widgetBase is Action)
            {
                var akcja = widgetBase as Action;
                var a = UtworzAkcja(akcja, viewer);
                panelRodzic.Controls.Add(a);
            }
            else
            if (widgetBase is Panel)
            {
                var oPanel = widgetBase as Panel;
                var panel = NsPanel.UtworzPanel(oPanel);

                panelRodzic.Controls.Add(panel);
                foreach (var element in oPanel.Elementy)
                {
                    GenerujElementy(element, panel, viewer, isPostBack);
                }
            }
            else if (widgetBase is TabsWidget)
            {
                GenerujTaby((TabsWidget)widgetBase, panelRodzic, viewer, isPostBack);
            }
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

                var kontrolka = GenerujKontrolke(widgetBase, panelRodzic, viewer, isPostBack);

                var kont = kontrolka as WebControl;
                if (kont != null)
                {
                    kont.Style["display"] = "block";
                    kont.Width = new Unit("99%");
                    kont.Style[HtmlTextWriterStyle.MarginBottom] = "10px";
                }

                panelRodzic.Controls.Add(kontrolka);
            }
        }

        private void GenerujTaby(TabsWidget widgetBase, NsPanel panelRodzic, IViewer viewer, bool isPostBack)
        {
            var tabs = NsTabs.UtworzTabs(widgetBase);
            panelRodzic.Controls.Add(tabs.Panel);
            foreach (var widgetBaseTab in widgetBase.Tabs)
            {
                var tab = NsPanel.UtworzPanel(widgetBaseTab);
                GenerujElementy(widgetBaseTab, tab, viewer, isPostBack);
                tabs.AddTab(tab);
            }
            
        }

        #region Tworzenie elementu

        private RadLabel UtworzLabel(string p)
        {
            return new RadLabel() { Text = p };
        }

        public NsAction UtworzAkcja(Action opisAkcji, IViewer viewer)
        {
            opisAkcji.Viewer = viewer;
            var akcja = new NsAction() { Widget = opisAkcji, ToolTip = opisAkcji.ToolTip, Text = opisAkcji.GetReadableName() };
            
            //if (opisAkcji.UrlIkony != null)
            //{
            //    var ui = new MenadzerUI();
            //    akcja.Icon.PrimaryIconUrl = ui.Ikony.Pobierz(opisAkcji.UrlIkony, 16);
            //}

            return akcja;
        }

        protected Control GenerujKontrolke(WidgetBase widget, NsPanel panel, IViewer viewer, bool isPostBack)
        {
            if (widget is ComboBox)
            {
                return NsComboBox.UtworzComboBox((ComboBox)widget);
            }

            if (widget is AutoCompleteBox)
            {
                return NsAutoComplete.UtworzAutoComplete((AutoCompleteBox)widget);
            }

            if (widget is DateTimePicker)
            {
                return NsDateTimePicker.UtworzDate((DateTimePicker)widget);
            }

            //if (widget is OpisCheckBox)
            //{
            //    return UtworzCheckBox(widget as OpisCheckBox);
            //}

            //if (widget is OpisAutoComplete)
            //{
            //    return UtworzAutoCompleteBox((OpisAutoComplete)widget);
            //}

            if (widget is TreeView)
            {
                return NsTreeView.UtworzTreeView((TreeView)widget);
            }

            if (widget is TreeComboBox)
            {
                return NsTreeComboBox.UtworzComboBox((TreeComboBox)widget);
            }

            if (widget is GridView)
            {
                return NsGrid.UtworzGridView((GridView)widget, isPostBack, panel.Page);
            }

            if (widget is CheckBox)
            {
                return NsCheckBox.UtworzCheckBox((CheckBox)widget);
            }

            if (widget is Label)
            {
                return NsLabel.CreateLabel(widget);
            }

            //if (widget is OpisEdytora)
            //{
            //    return UtworzEdytor((OpisEdytora)widget);
            //}

            var tb= NsTextBox.UtworzTextBox((TextBox) widget);
            if(string.IsNullOrEmpty(widget.Height?.ToString()) == false)
            {
                tb.TextMode = InputMode.MultiLine;
                tb.Height = new Unit(widget.Height.ToString());
            }

            return tb;
        }

       

        #endregion
    }
}
