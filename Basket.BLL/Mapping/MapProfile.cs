using AutoMapper;
using Basket.BLL.DTOs;
using Basket.Entities.Entities;

namespace Basket.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<TblItem, ItemDTO>().ReverseMap();

        }
    }
}
