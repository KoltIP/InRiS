using AutoMapper;
using B.Data.Entities;

namespace B.Models
{
    public class DivisionModel
    {
        public string Name { get; set; } = String.Empty;
        public Status Status { get; set; }
        public string? ParentName { get; set; } = null;
    }

    public class DivisionModelProfile : Profile
    {
        public DivisionModelProfile()
        {
            CreateMap<Division, DivisionModel>();
        }
    }

    public class DivisionProfile : Profile
    {
        public DivisionProfile()
        {
            CreateMap<DivisionModel, Division>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.ParentName));
        }
    }    
}
