using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Builders
{
    public class TextBoxBuilder<T> : WidgetBuilderBase<TextBox<T>, TextBoxBuilder<T>>
    {
        public TextBoxBuilder(TextBox<T> component) : base(component)
        {
        }

        /// <summary>
        /// Enables or disables the textbox.
        /// </summary>
        /// <param name="isEnabled"></param>
        /// <returns></returns>
        public TextBoxBuilder<T> Enable(bool isEnabled)
        {
            base.Component.Enabled = isEnabled;
            return this;
        }

        /// <summary>
        /// Sets the initial format of the TextBox.
        /// </summary>
        /// <param name="format"></param>
        public TextBoxBuilder<T> Format(string format)
        {
            base.Component.Format = format;
            return this;
        }

        /// <summary>
        /// Sets the initial value of the TextBox.
        /// </summary>
        public TextBoxBuilder<T> Value(T value)
        {
            base.Component.Value = value;
            return this;
        }
    }
}
