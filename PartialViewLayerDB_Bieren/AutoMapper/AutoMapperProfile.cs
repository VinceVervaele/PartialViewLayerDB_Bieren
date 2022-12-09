using AutoMapper;
using PartialView.Models.Entities;
using PartialViewLayerDB_Bieren.ViewModels;

namespace PartialViewLayerDB_Bieren.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Beer, BierVM>().ForMember(a => a.Brouwernaam, b => b.MapFrom(c => c.BrouwernrNavigation.Naam))
                .ForMember(a => a.Soortnaam, b => b.MapFrom(c => c.SoortnrNavigation.Soortnaam));

            CreateMap<Brewery, BrewerVM>();

            //CreateMap<Beer, BeerVM>().ForMember(dest => dest.BrouwerNaam,
            //    opts => opts.MapFrom(
            //        src => src.BrouwernrNavigation.Naam

            //    ))
            //                    .ForMember(dest => dest.SoortNaam,
            //        opts => opts.MapFrom(
            //            src => src.SoortnrNavigation.Soortnaam
            //        ));
        }
    }
}
