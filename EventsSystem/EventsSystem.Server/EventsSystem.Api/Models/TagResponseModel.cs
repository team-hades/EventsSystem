namespace EventsSystem.Api.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using EventsSystem.Api.Infrastructure.Mapping;
    using EventsSystem.Data.Models;

    public class TagResponseModel : IMapFrom<Tag>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public int EventsCount { get; set; }

        public List<EventResponseModel> Events { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Tag, TagResponseModel>()
                .ForMember(t => t.EventsCount, opts => opts.MapFrom(e => e.Events.Count))
                .ForMember(t => t.Events, opts => opts.MapFrom(e => e.Events.OrderByDescending(x => x.StartDate).ToList()));
        }
    }
}