using AutoMapper;
using Saityno4darbas.BLL.DtoModels;
using Saityno4darbas.DAL.Models;

namespace Saityno4darbas.BLL.Infastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CatDto, Cat>().ReverseMap();
        }
    }
}