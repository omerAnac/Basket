using AutoMapper;
using Basket.BLL.DTOs;
using Basket.Redis.Entities;
using Basket.Redis.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Redis.Mapping
{
    public class BasketMapProfile : Profile
    {
        public BasketMapProfile()
        {
            CreateMap<TblBasket, BasketDTO>().ReverseMap();

        }
    }
}
