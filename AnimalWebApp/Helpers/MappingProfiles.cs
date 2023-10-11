using AnimalWebApp.Models;
using AnimalWebApp.Models.ViewModels;
using AutoMapper;

namespace AnimalWebApp.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Tag, EditTagRequest>().ReverseMap();
        CreateMap<Tag, AddTagRequest>().ReverseMap();
        CreateMap<AnimalPost, AddAnimalPostRequest>().ReverseMap();
    }
}