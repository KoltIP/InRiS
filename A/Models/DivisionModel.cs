using A.Data.Entities;
using AutoMapper;

namespace A.Services.Division.Models
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
            CreateMap<DivisionModel,Data.Entities.Division>();
        }
    }
}
