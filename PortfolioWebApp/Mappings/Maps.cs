using AutoMapper;
using PortfolioWebApp.Data;
using PortfolioWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<Post, PostEditViewModel>().ReverseMap();
            CreateMap<About, AboutOwnerViewModel>().ReverseMap();
        }
    }
}
