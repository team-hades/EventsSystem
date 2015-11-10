namespace EventsSystem.Api.Models
{
    using System;
    using Infrastructure.Mapping;
    using Data.Models;
    using Infrastructure;
    using AutoMapper;

    public class EventSaveModel : IMapFrom<EventResponseModel>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string ShortDescrtiption { get; set; }

        public bool IsPrivate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TownId { get; set; }

        public int CategoryId { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<EventResponseModel, Event>()
                .ForMember(e => e.Town, opts => opts.Ignore())
                .ForMember(e => e.Category, opts => opts.Ignore());
        }
    }
}