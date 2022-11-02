using AutoMapper;

namespace B.Models
{
    public class SerializeDivisionModel
    {
        public string Name { get; set; } = null;
        public string? ParentName { get; set; } = null;
        public List<SerializeDivisionModel> Divisions { get; set; }
    }

    public class ParseDivisionProfile : Profile
    {
        public ParseDivisionProfile()
        {
            CreateMap<SerializeDivisionModel, DivisionModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.ParentName));
        }
    }
}
