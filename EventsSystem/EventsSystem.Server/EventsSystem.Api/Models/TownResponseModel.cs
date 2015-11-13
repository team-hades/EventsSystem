namespace EventsSystem.Api.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;

    using Data.Models;
    using Infrastructure.Mapping;

    public class TownResponseModel : IMapFrom<Town>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<EventResponseModel> Events
        {
            get; set;
        }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Town, TownResponseModel>()
                .ForMember(e => e.Events, opts => opts.MapFrom(c => c.Events.OrderByDescending(x => x.StartDate).ToList()));
        }
    }
}