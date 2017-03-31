﻿using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Widgets.DataWidgets
{
    public class AutoCompleteFactory<T> : ItemsWidgetsFactory<T>
    {
        public AutoCompleteBox AutoComplete => Widget as AutoCompleteBox;
    }
}
