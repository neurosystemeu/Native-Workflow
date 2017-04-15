﻿using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Builders
{
    public class PanelItemFactory
    {
        private Panel container;
        private PanelBuilder panelBuilder;

        public PanelItemFactory(Panel container)
        {
            this.container = container;
        }

        public PanelItemFactory(Panel container, PanelBuilder panelBuilder) : this(container)
        {
            this.panelBuilder = panelBuilder;
        }

        public virtual PanelBuilder Add()
        {
            var item = new Panel();
            container.Items.Add(item);
            return new PanelBuilder(item);
        }
    }
}
