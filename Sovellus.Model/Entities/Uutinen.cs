using System;

namespace Sovellus.Model.Entities
{
    public class Uutinen
    {
        public long Id { get; set; }
        public int RavintolaId { get; set; }
        public string Teksti { get; set; }
        public DateTime Aika { get; set; }
        public DateTime JulkaisuAika { get; set; }
        public Ravintola Ravintola { get; set; }
    }
}
