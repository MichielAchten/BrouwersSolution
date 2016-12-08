using KazenClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KazenService.Models
{
    public class InMemoryDataBase
    {
        private static Dictionary<int, Kaas> kazenValue;
        static InMemoryDataBase()
        {
            var oudBrugge = new Kaas { ID = 1, Naam = "Oud Brugge", Type = "hard", Smaak = "pittig" };
            var watou = new Kaas { ID = 2, Naam = "Watou", Type = "halfhard", Smaak = "zacht" };
            var wynenDaele = new Kaas { ID = 3, Naam = "WynenDaele", Type = "zacht", Smaak = "pittig" };
            var laPrihel = new Kaas { ID = 4, Naam = "La Prihel", Type = "vers", Smaak = "pittig" };
            var grevenBroucker = new Kaas { ID = 5, Naam = "GrevenBroucker", Type = "blauwgeaderd", Smaak = "romig" };
            kazenValue = new Dictionary<int, Kaas> {
            {oudBrugge.ID, oudBrugge},{watou.ID, watou}, {wynenDaele.ID, wynenDaele},{laPrihel.ID, laPrihel},{grevenBroucker.ID, grevenBroucker}};
        }
        public static Dictionary<int, Kaas> Kazen
        {
            get
            {
                return kazenValue;
            }
        }
    }
}