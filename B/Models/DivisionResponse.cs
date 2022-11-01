using AutoMapper;

namespace B.Models
{
    public class DivisionResponse
    {
        public string Name { get; set; } = null;
        public string Status { get; set; } = null;
        public string? ParentName { get; set; } = null;
    }

    public class DivisionResponseProfile : Profile
    {
        public DivisionResponseProfile()
        {
            CreateMap<DivisionModel, DivisionResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.ParentName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
