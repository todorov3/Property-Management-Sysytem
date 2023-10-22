using AutoMapper;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;

namespace PropertyManagementSystem.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Property, PropertyCreateDto>().ReverseMap();
            CreateMap<Property, PropertyUpdateDto>().ReverseMap();

            CreateMap<Feedback, FeedbackCreateDto>().ReverseMap();
            CreateMap<Feedback, FeedbackUpdateDto>().ReverseMap();
            CreateMap<Feedback, FeedbackResponseDto>().ReverseMap();

            CreateMap<Request, RequestCreateDto>().ReverseMap();
        }
    }
}
