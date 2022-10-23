using AutoMapper;
using PRJGBS.Models;
using PRJGBS.Models.Dto;

namespace PRJGBS.API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Player, PlayerDTO>().ReverseMap();
            CreateMap<Player, PlayerCreateDTO>().ReverseMap();
        }
    }
}
