using System.Collections.Generic;

namespace Sovellus.Model.Entities
{
    public class Ravintola
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public int KaupunkiId { get; set; }
        public int? TyyppiId { get; set; }
        public string Katuosoite { get; set; }
        public string Postinro { get; set; }
        public string KuvaUrl { get; set; }
        public string KotisivuUrl { get; set; }
        public ICollection<Arviointi> Arvioinnit { get; set; }
        public Kaupunki Kaupunki { get; set; }
        public ICollection<Uutinen> Uutiset { get; set; }
        public RavintolaTyyppi RavintolaTyyppi { get; set; }
    }
}
