using AutoMapper;

namespace A.Services.Division.Models
{
    public class DivisionModel
    {
        public string Name { get; set; } = string.Empty;
        public Status Status { get; set; }
        public string UpperName { get; set; }
    }

    public class DivisionModelProfile : Profile
    {
        public DivisionModelProfile()
        {
            CreateMap<Data.Entities.Division, DivisionModel>();
        }
    }
}
