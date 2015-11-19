namespace EventsSystem.Api.Models.Events
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using AutoMapper;

    using EventsSystem.Api.Infrastructure.Mapping;
    using Comments;
    using EventsSystem.Data.Models;

    public class EventsForUserResponseModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string ShortDescrtiption
        {
            get; set;
        }

        public DateTime StartDate
        {
            get; set;
        }

        public DateTime EndDate
        {
            get; set;
        }

        public string Town
        {
            get; set;
        }

        public string Category
        {
            get; set;
        }

        public float Rating
        {
            get; set;
        }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Event, EventResponseModel>()
                .ForMember(e => e.Town, opts => opts.MapFrom(t => t.Town.Name))
                .ForMember(e => e.Category, opts => opts.MapFrom(t => t.Category.Name))
                .ForMember(e => e.Rating, opts => opts.MapFrom(e => e.Ratings.Any() ? e.Ratings.Average(r => r.Value) : 0.0f));
        }
    }
}