using AutoMapper;
using PartialView.Models.Entities;
using PartialViewLayerDB_Bieren.ViewModels;

namespace PartialViewLayerDB_Bieren.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Beer, BierVM>();
        }
    }
}
