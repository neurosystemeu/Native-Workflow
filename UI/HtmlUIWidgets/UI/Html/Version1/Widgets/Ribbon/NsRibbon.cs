using System.Collections.Generic;
using System.Linq;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Actions;
using Telerik.Web.UI;
using Action = NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Actions.Action;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version1.Widgets.Ribbon
{
    public class NsRibbon : RadRibbonBar, IBindingControl
    {
        public NsRibbon()
        {
            this.Command += NsRibbonW_Command;
        }

        #region Propercje

        public WidgetBase Widget { get; set; }
        public List<Action> Akcje { get; set; }

        #endregion

        void NsRibbonW_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            //var ribbonAkcja = sender as NsRibbonAkcja;
            //var stronaMW = this.Page as StronaBazowaMW;
            //stronaMW.ZapiszDoMWZKontrolki();
            //Binding.WykonajAkcje(ribbonAkcja.OpisWidoku.AkcjaBinding, this, new NeuroSystem.Wersja1.UI.Klasy.ArgumentBazowy() { NazwaAkcji = ribbonAkcja.OpisWidoku.Nazwa });
            //stronaMW.ZapiszDoKontrolkiZMW();
            ////Kontroler.KliknietoAkcje(ribbonAkcja);
        }


        #region Kreator

        public static NsRibbon UtworzRibbonBar(List<Action> akcje)
        {
            //generuje ribbona
            //sprawdzam czy jest menu ribbon
            var akcjeRibbon = akcje.Where(o => o.Position == EnumActionPosition.Ribbon);
            if (akcjeRibbon.Any())
            {
                //mamy menu ribon
                var ribonBar = new NsRibbon();

                foreach (var opisAkcji in akcjeRibbon)
                {
                    var tab = ribonBar.Tabs.FirstOrDefault(r => r.Value == opisAkcji.Tab);

                    if (tab == null)
                    {
                        tab = new RibbonBarTab()
                        {
                            Value = opisAkcji.Tab,
                            Text = WidgetBase.GetReadableName(opisAkcji.Tab)
                        };

                        ribonBar.Tabs.Add(tab);
                    }

                    var grupa = tab.Groups.FirstOrDefault(g => g.Value == opisAkcji.Group);
                    if (grupa == null)
                    {
                        grupa = new RibbonBarGroup()
                        {
                            Value = opisAkcji.Group,
                            Text = WidgetBase.GetReadableName(opisAkcji.Group)
                        };
                    }

                    tab.Groups.Add(grupa);
                    var ribonButton = utworzRibbonAkcja(opisAkcji);
                    grupa.Items.Add(ribonButton);

                }



                return ribonBar;
            }

            return null;
        }

        private static NsRibbonAction utworzRibbonAkcja(Action opisAkcji)
        {
            var opis = opisAkcji;
            var ribonButton = new NsRibbonAction();
            ribonButton.Widget = opis;
            ribonButton.ToolTip = opisAkcji.ToolTip;
            //ribonButton.ID = opisAkcji.Nazwa;
            ribonButton.Text = opisAkcji.Label.ToString();
            //ribonButton.CommandName = opisAkcji.Nazwa;
            ribonButton.Widget = opisAkcji;
            switch (opis.Size)
            {
                case EnumActionSize.Small:
                    ribonButton.Size = RibbonBarItemSize.Small;
                    //ribonButton.ImageUrl = MenadzerIkon.PobierzUrlIkony(opis.NazwaIkony, 16);
                    break;
                case EnumActionSize.Normal:
                    ribonButton.Size = RibbonBarItemSize.Medium;
                    //ribonButton.ImageUrl = MenadzerIkon.PobierzUrlIkony(opis.NazwaIkony, 16);
                    break;
                case EnumActionSize.Big:
                    ribonButton.Size = RibbonBarItemSize.Large;
                    //ribonButton.ImageUrlLarge = MenadzerIkon.PobierzUrlIkony(opis.NazwaIkony, 32);
                    break;
            }

            return ribonButton;
        }

        #endregion

        public void DodajTab(NsRibbonTab tab)
        {
            Tabs.Add(tab as RibbonBarTab);
        }

        public void LoadToControl()
        {
        }

        public void SaveFromControl()
        {
        }

        public List<NsRibbonTab> Taby
        {
            get
            {
                return Tabs.OfType<NsRibbonTab>().ToList();
            }
        }

        
    }
}