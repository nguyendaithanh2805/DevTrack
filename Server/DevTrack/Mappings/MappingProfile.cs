using AutoMapper;
using DevTrack.DTOs;
using DevTrack.Models;

namespace DevTrack.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TblUser, UserDTO>().ReverseMap();
        }
    }
}
