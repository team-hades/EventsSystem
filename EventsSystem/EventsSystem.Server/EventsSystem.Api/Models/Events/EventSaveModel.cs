namespace EventsSystem.Api.Models.Events
{
	using System;

	using AutoMapper;

	using EventsSystem.Api.Infrastructure.Mapping;
	using EventsSystem.Data.Models;
	using System.Collections.Generic;

	public class EventSaveModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string ShortDescrtiption { get; set; }

        public bool IsPrivate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Town { get; set; }

        public string Category { get; set; }

		public IList<string> Tags { get; set; }

		public void CreateMappings(IConfiguration config)
        {
			config.CreateMap<EventSaveModel, Event>()
				.ForMember(e => e.Town, opts => opts.Ignore())
                .ForMember(e => e.Tags, opts => opts.Ignore())
                .ForMember(e => e.Category, opts => opts.Ignore());
		}
    }
}