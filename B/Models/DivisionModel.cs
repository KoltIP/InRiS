using AutoMapper;

namespace B.Models
{
    public class DivisionModel
    {
        public string Name { get; set; } = null;
        public Status Status { get; set; }
        public string? ParentName { get; set; } = null;
    }

    public class DivisionModelProfile : Profile
    {
        public DivisionModelProfile()
        {
            CreateMap<Data.Entities.Division, DivisionModel>();
        }
    }

    public class DivisionProfile : Profile
    {
        public DivisionProfile()
        {
            CreateMap<DivisionModel, Data.Entities.Division>();
        }
    }

    public class ParseDivisionProfile : Profile
    {
        public ParseDivisionProfile()
        {
            CreateMap<SerializeDivisionModel, DivisionModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.ParentName));
        }
    }
}
