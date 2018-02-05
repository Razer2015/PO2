namespace Sovellus.Model.Entities
{
    public class Ravintola
    {
        public int? Id { get; set; }
        public string Nimi { get; set; }
        public int? KaupunkiId { get; set; }
        public int TyyppiId { get; set; }
        public string Katuosoite { get; set; }
        public string Postinro { get; set; }
        public string KuvaUrl { get; set; }
        public string KotisivuUrl { get; set; }
    }
}
