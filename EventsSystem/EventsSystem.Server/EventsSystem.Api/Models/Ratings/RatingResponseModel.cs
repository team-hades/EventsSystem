namespace EventsSystem.Api.Models
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Data.Models;

    public class RatingResponseModel : IMapFrom<Rating>, IHaveCustomMappings
    {
        public int Id
        {
            get; set;
        }

        public float Value
        {
            get; set;
        }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Rating, RatingResponseModel>()
                .ForMember(r => r.Value, opts => opts.MapFrom(e => e.Value));
        }
    }
}