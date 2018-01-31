using System.ComponentModel.DataAnnotations;

namespace PO2Sovellus.ViewModels
{
    public class RavintolaEditViewModel
    {
        [Required(ErrorMessage = "Nimi on pakollinen"), MaxLength(200)]
        public string Nimi { get; set; }
    }
}
