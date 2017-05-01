using System;
using System.Collections.Generic;
using System.ComponentModel;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.DataAnnotations;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.TestViews
{
    public class PracownikTest 
    {
        public Guid Id { get; set; }

        #region Dane podstawowe 

        public string Nazwa => Imie + " " + Nazwisko;

        [Description("Imię pracownika")]
        [GridView(Aggregate = GridAggregateFunction.Count, VisibleMode = EnumGridColumnVisibleMode.SmallAndBigList)]
        [DataFormView]
        public string Imie { get; set; }

        [Description("Nazwisko pracownika")]
        [GridView(VisibleMode = EnumGridColumnVisibleMode.SmallAndBigList)]
        [DataFormView]
        public string Nazwisko { get; set; }

        [Description("Telefon")]
        [GridView()]
        [DataFormView]
        public string Telefon { get; set; }

        [Description("Miasto zamieszkania")]
        [GridView(VisibleMode = EnumGridColumnVisibleMode.SmallAndBigList)]
        [DataFormView(GroupName = "Adres")]
        public string Miasto { get; set; }

        [Description("Adres zamieszkania")]
        [DataFormView(GroupName = "Adres")]
        public string Adres { get; set; }

        [Description("Kod pocztowy zamieszkania")]
        [DataFormView(GroupName = "Adres")]
        public string KodPocztowy { get; set; }

        [Description("Rodzaj pracownika")]
        [DataFormView]
        public EnumRodzajPracownika RodzajPracownika { get; set; }

        [Description("Czy posiada prawo jazdy")]
        [GridView(FilterFunction = GridKnownFunction.EqualTo)]
        [DataFormView]
        public bool CzyMaPrawoJazdy { get; set; }

        [Description("Czy aktualnie współpracuje/pracuje")]
        [DataFormView]
        [GridView(FilterFunction = GridKnownFunction.EqualTo, FilterDefaultValue = "True")]
        public bool Aktywny { get; set; }

        //[Description("Status pracownika")]
        //[GridView]
        //[DataFormView]
        //public EnumStatusPracownika StatusPracownika { get; set; }

        #endregion

        #region Dane kadrowe 

        

        //[Description("Jednostka organizacyjna Id")]
        //[DataFormView(RepositoryType = typeof(JednostkaOrganizacyjna), GroupName = "Kadrowe", TabName = "Kadrowe")]
        //public Guid? JednostkaOrganizacyjnaId { get; set; }

        //[Description("Jednostka organizacyjna do której należy pracownik")]
        //public JednostkaOrganizacyjna JednostkaOrganizacyjna { get; set; }

        [GridView]
        public string JednostkaOrganizacyjnaNazwa { get; set; }

        [Description("Pesel pracownika")]
        [DataFormView(GroupName = "Kadrowe", TabName = "Kadrowe")]
        public string Pesel { get; set; }

        [Description("Seria i numer dowodu osobistego lub innego dokumentu tożsamości")]
        [DataFormView(GroupName = "Kadrowe", TabName = "Kadrowe")]
        public string SeriaINrDowodu { get; set; }

        //[Description("Umowy pracownika w naszej firmie")]
        //public IList<UmowaPracownika> UmowyPracownika { get; set; }

        [Description("Stanowisko pracownika")]
        [DataFormView(GroupName = "Kadrowe", TabName = "Kadrowe")]
        [GridView]
        public string Stanowisko { get; set; }

        [Description("Przełożony pracownika")]
        [DataFormView(RepositoryType = typeof(PracownikTest), GroupName = "Kadrowe", TabName = "Kadrowe", 
            ListViewUrl = "~/sdfsdf")]
        public Guid? PrzelozonyId { get; set; }

        [DataFormView(ControlType = EnumControlType.Grid)]
        public List<PracownikTest> Podwladni { get; set; }
        
        [DataFormView(GroupName = "Informacje", TabName = "Kadrowe")]
        public string NumerButa { get; set; }

        [DataFormView(GroupName = "Informacje", TabName = "Kadrowe")]
        public string Wzrost { get; set; }

        [DataFormView(GroupName = "Informacje", TabName = "Kadrowe")]
        public string RozmiarSpodni { get; set; }

        [DataFormView(GroupName = "Informacje", TabName = "Kadrowe")]
        public string RozmiarKasku { get; set; }

        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        [GridView(Aggregate = GridAggregateFunction.Min)]
        public DateTime? DataWaznosciBadan { get; set; }

        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        [GridView(Aggregate = GridAggregateFunction.Min)]
        public DateTime? DataWaznosciSzkoleniaBHP { get; set; }

        #endregion

        #region Finansowe

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public decimal? StawkaGodzinowa { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public string WymiarEtatu { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public decimal? KwotaNettoNaUmowie { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public decimal? KwotaBruttoNaUmowie { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public decimal StalaPremia { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public decimal StawkaGodzinowaKoszty { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public string StawkaNaOkresProbny { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public string StawkaDocelowa { get; set; }

        [DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public int IloscDniUrlopuWRoku { get; set; }


        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        public DateTime? DataZatrudnienia { get; set; }

        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        [GridView(Aggregate = GridAggregateFunction.Min)]
        public DateTime? DoKiedyUmowa { get; set; }

        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        public DateTime? DataZwolnienia { get; set; }

        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        public DateTime? DataRozpoczeciaWspolpracy { get; set; }

        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        public DateTime? DataZakonczeniaWspolpracy { get; set; }


        #endregion



        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Imie) && !string.IsNullOrEmpty(Nazwisko))
            {
                return Imie + " " + Nazwisko;
            }
            else if (!string.IsNullOrEmpty(Imie))
            {
                return Imie;
            }
            else if (!string.IsNullOrEmpty(Nazwisko))
            {
                return Nazwisko;
            }

            return null;
        }
        
    }

    #region Enumy
    [Description("Rodzaj pracownika")]
    public enum EnumRodzajPracownika
    {
        [Description("Pracownicy - produkujący - pracownicy fizyczni. Pracownik produkcyjny jest odpowiedzialny za wytwarzanie towarów lub usług. W odrurznieniu od pracowników biurowych, których zadaniem jest organizowanie produkcji")]
        Produkcyjny,
        [Description("Pracownik organizujący produkcję")]
        Biurowy,
        [Description("Pracownik organizujący produkcję")]
        Kierownik
    }
    #endregion
}
