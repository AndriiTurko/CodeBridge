using AutoMapper;
using CodeBridge.Entities;
using CodeBridge.Models;

namespace CodeBridge.MappingProfiles
{
    public class DogProfile : Profile
    {
        public DogProfile()
        {
            CreateMap<Dog, DogForCreationDTO>().ReverseMap();
            CreateMap<Dog, DogDTO>().ReverseMap();
        }
    }
}
