﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version2.Builders
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="T:Kendo.Mvc.UI.DataSource" /> AJAX create/update/destroy operation bindings.
    /// </summary>
    public class AjaxDataSourceBuilder<TModel> : AjaxDataSourceBuilderBase<TModel, AjaxDataSourceBuilder<TModel>>
    where TModel : class
    {
        public AjaxDataSourceBuilder(DataSource dataSource) : base(dataSource)
        {
        }

        
    }
}