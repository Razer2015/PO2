using PO2Sovellus.Entities;
using System.Collections.Generic;

namespace PO2Sovellus.ViewModels
{
    public class EtusivuViewModel
    {
        public IEnumerable<Ravintola> Ravintolat { get; set; }
        public string Otsikko { get; set; }
    }
}
