﻿using System.Collections.Generic;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Panels
{
    public class Panel : WidgetBase
    {
        public Panel()
        {
            Elementy = new List<WidgetBase>();
        }

        public EnumPanelFloat Float { get; set; }
        public EnumPanelClear Clear { get; set; }
        public EnumPanelOrientation Orientation { get; set; }
        public List<WidgetBase> Elementy { get; set; }

        /// <summary>
        /// Przeszukuje za elementem danej nazwy
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public WidgetBase GetWidgetByName(string name)
        {
            foreach (var widgetBase in Elementy)
            {
                if (widgetBase.Name == name)
                {
                    return widgetBase;
                }

                var panel = widgetBase as Panel;
                if (panel != null)
                {
                    var wynik = panel.GetWidgetByName(name);
                    if (wynik != null)
                    {
                        return wynik;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Zwraca pierwszy element typu T z elementów panelu (oraz pod paneli)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetWidgetByType<T>() where T: WidgetBase 
        {
            foreach (var widgetBase in Elementy)
            {
                if (widgetBase is T)
                {
                    return widgetBase as T;
                }

                var panel = widgetBase as Panel;
                if (panel != null)
                {
                    var wynik = panel.GetWidgetByType<T>();
                    if (wynik != null)
                    {
                        return wynik;
                    }
                }
            }

            return default(T);
        }

        public override void SetDataContext(object dataContext)
        {
            foreach (var widgetBase in Elementy)
            {
                widgetBase.SetDataContext(dataContext);
            }
        }
    }
}
