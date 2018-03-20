using AutoMapper;
using PO2Sovellus.ViewModels;
using Sovellus.Model.Entities;

namespace PO2Sovellus.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize() {
            Mapper.Initialize(config =>
            {
                config.CreateMap<RavintolaApiViewModel, Ravintola>();
            });
        }
    }
}
