using AutoMapper;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using WebViewModels;

namespace Services.Helpers
{
   public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserViewModel>()
                .ReverseMap();
            CreateMap<Event, EventViewModel>()
                .ReverseMap();
                
        }
    }
}
