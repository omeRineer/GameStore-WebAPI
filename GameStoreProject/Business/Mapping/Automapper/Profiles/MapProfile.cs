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
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Game, GameDto>()
                .ForMember(x => x.DeveloperName, s => s.MapFrom(y => y.Company.Name))
                .ForMember(x => x.DistributorName, s => s.MapFrom(y => y.Company.Name));

            CreateMap<GameImageUploadDto,GameImage>();
            CreateMap<GameImageUploadDto, List<GameImage>>()
                .ConstructUsing(x=>x.FileCollection.Select(s=>new GameImage
                {
                    GameId=x.GameId,
                    ImagePath=s.FileName
                }).ToList());
        }
    }
}
