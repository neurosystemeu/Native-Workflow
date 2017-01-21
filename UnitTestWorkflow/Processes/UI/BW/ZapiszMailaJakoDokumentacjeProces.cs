using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.Core.Process.ProcessWithUI.Html;

namespace UnitTestWorkflow.Processes.UI.BW
{
    public class DaneZapiszMailaJakoFokumentacje
    {
        public Guid MailId { get; set; }

        [Display]
        //public Projekt Projekt { get; set; }
        public Guid? ProjektId { get; set; }

        [Description("Jeśli oferta jest tylko w treści maila to możemy ją zapisać na dysku")]
        [Display]
        public bool CzyZapisacTrescMaila { get; set; }

        [Description("Nazwa pod folderu folderu ..projekt/Oferty/ - np. do rozdzielania na działy - np. wentylacja,CO...")]
        [Display]
        public string NazwaFolderu { get; set; }

        [Description("Nazwa oferty - taki folder zostanie utworzony - do rozdzielania na producentów itp. np. bims, hydro...")]
        [Display]
        public string NazwaDokumentacji { get; set; }
    }

    public class ZapiszMailaJakoDokumentacjeProces : EditProcess<DaneZapiszMailaJakoFokumentacje>
    {
        public DaneZapiszMailaJakoFokumentacje Dane { get; set; }

        public override object Start()
        {

            var formatka = this.CreateDataFormView<DaneZapiszMailaJakoFokumentacje>(Dane);//new FormatkaDynamiczna<DaneZapiszMailaJakoFokumentacje>(Dane)

            formatka.AddAction("Dalej");
            formatka.AddAction("Anuluj");
            formatka.AddField(p => p.NazwaFolderu);

            //Formatka.OpisWidoku.NazwaBinding = "Dodawanie nowego użytkownika";

            var wynik = ShowView(formatka);
            if (wynik.ActionName == "Dalej")
            {
                Dane = this.UserDataInput as DaneZapiszMailaJakoFokumentacje;
                if (Dane != null && Dane.ProjektId != null)
                {
                    zapiszMailaJakoDokumentacje(Dane);
                    EndProcess("Dodano maila i załączniki jako oferte - do folderu projektu z ofertami oraz maila do folderu oferty");
                }
                else
                {
                    EndProcess("Nie zapisano oferty - należy wybrać projekt");
                }
            }
            else
            {
                EndProcess("Anulowano proces");
            }

            return null;
        }

        private void zapiszMailaJakoDokumentacje(DaneZapiszMailaJakoFokumentacje dane)
        {
        }
    }
}
