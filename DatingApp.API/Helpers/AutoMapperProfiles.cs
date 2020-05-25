using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // destination => propiedad PhotoUrl, options => MapFrom, source => Propiedad IsMain de la lista de Photos
            CreateMap<User, UserForListDto>()
                .ForMember(destination => destination.PhotoUrl, options =>
                 options.MapFrom(source => source.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(destiantion => destiantion.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForDetailDto>()
                .ForMember(destination => destination.PhotoUrl, options =>
                 options.MapFrom(source => source.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(destiantion => destiantion.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotosForDetailDto>();
        }
    }
}