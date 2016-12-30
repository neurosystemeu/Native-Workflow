using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent
{
    public class WidgetFactory
    {
        public WidgetBase Widget { get; set; }
    }

    public class WidgetFactory<T> : WidgetFactory
    {
        public WidgetFactory<T> Height(string height)
        {
            Widget.Height = height;
            return this;
        }

        public WidgetFactory<T> HeightBinding(string heightPath)
        {
            Widget.Height = new Binding(heightPath);
            return this;
        }

        public WidgetFactory<T> Width(string width)
        {
            Widget.Width = width;
            return this;
        }

        public WidgetFactory<T> WidthBinding(string widthPath)
        {
            Widget.Width = new Binding(widthPath);
            return this;
        }

        public WidgetFactory<T> Label(string lable)
        {
            Widget.Label = lable;
            return this;
        }

        public WidgetFactory<T> LabelBinding(string lablePath)
        {
            Widget.Label = new Binding(lablePath);
            return this;
        }

        public WidgetFactory<T> Tooltip(string tooltip)
        {
            Widget.ToolTip = tooltip;
            return this;
        }

        public WidgetFactory<T> Name(string name)
        {
            Widget.Name = name;
            return this;
        }

        public WidgetFactory<T> CssClass(string cssClass)
        {
            Widget.CssClass = cssClass;
            return this;
        }

        public WidgetFactory<T> DataContext(object dataContext)
        {
            Widget.DataContext = dataContext;
            return this;
        }

        public WidgetFactory<T> DataContextBinding(string dataContextPath)
        {
            Widget.DataContext = new Binding(dataContextPath);
            return this;
        }
    }
}
