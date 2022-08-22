using AutoMapper;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.Automapper.Profiles
{
    public class GameProfile:Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>()
                .ForMember(x => x.DeveloperName, s => s.MapFrom(y => y.Developer.Name))
                .ForMember(x => x.DistributorName, s => s.MapFrom(y => y.Distributor.Name));
        }
    }
}
