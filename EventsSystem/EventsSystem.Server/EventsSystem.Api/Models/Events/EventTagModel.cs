using EventsSystem.Api.Infrastructure.Mapping;
using EventsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace EventsSystem.Api.Models.Events
{
	public class EventTagModel : IMapFrom<Event>, IHaveCustomMappings
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string Category { get; set; }

		public string User { get; set; }

		public void CreateMappings(IConfiguration config)
		{
			config.CreateMap<Event, EventTagModel>()
				.ForMember(e=> e.Description, opts => opts.MapFrom(e => e.ShortDescrtiption))
				.ForMember(e => e.Category, opts => opts.MapFrom(e => e.Category.Name))
				.ForMember(e => e.User, opts => opts.MapFrom(e => e.Author.FirstName));
		}
	}
}