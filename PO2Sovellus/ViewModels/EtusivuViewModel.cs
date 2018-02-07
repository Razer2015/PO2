using Sovellus.Model.Entities;
using System.Collections.Generic;

namespace PO2Sovellus.ViewModels
{
    public class EtusivuViewModel
    {
        public ICollection<Ravintola> Ravintolat { get; set; }
        public string Otsikko { get; set; }
    }
}
