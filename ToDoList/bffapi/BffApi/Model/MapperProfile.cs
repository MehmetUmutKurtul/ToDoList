using AutoMapper;

namespace BffApi.Model {

    public class MapperProfile : Profile {
        public MapperProfile() {
            CreateMap<LoginDataAccess.Model.Login, Login>()  //yolları gösteriyoruz
                .ForMember(dest => dest.LoginId, opt => opt.MapFrom(src => src.Id));
            CreateMap<ToDoDataAccess.Model.ToDo, ToDo>()
                .ForMember(dest => dest.ToDoId, opt => opt.MapFrom(src => src.Id));
        }
    }

}