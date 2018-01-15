using Microsoft.Extensions.Configuration;

namespace PO2Sovellus
{
    public interface ITervehtija
    {
        string GetTervehdys();
    }
    public class Tervehtija : ITervehtija
    {
        private string _tervehdys;
        public Tervehtija(IConfiguration configuration) {
            _tervehdys = configuration["Tervehdys"];
        }
        public string GetTervehdys() {
            return (_tervehdys);
        }
    }
}
