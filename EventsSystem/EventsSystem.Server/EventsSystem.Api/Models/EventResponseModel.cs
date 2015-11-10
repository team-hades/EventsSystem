﻿namespace EventsSystem.Api.Models
{
    using System;

	using AutoMapper;

	using Infrastructure.Mapping;
    using Data.Models;

    public class EventResponseModel : IMapFrom<Event>, IHaveCustomMappings
    {
		public string Name { get; set; }

		public string ShortDescrtiption { get; set; }

		public bool IsPrivate { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

        public string Town { get; set; }

        public string Category { get; set;}

        public object CommentsCount { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Event, EventResponseModel>()
                .ForMember(e => e.CommentsCount, opts => opts.MapFrom(c => c.Comments.Count))
                .ForMember(e => e.Town, opts => opts.MapFrom(t => t.Town.Name))
                .ForMember(e => e.Category, opts => opts.MapFrom(t => t.Category.Name));
        }
    }
}