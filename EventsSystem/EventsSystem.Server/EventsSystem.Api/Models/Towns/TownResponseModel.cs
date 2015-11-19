namespace EventsSystem.Api.Models.Towns
{
	using System.Collections.Generic;
	using System.Linq;
	using AutoMapper;

	using EventsSystem.Api.Infrastructure.Mapping;
	using EventsSystem.Api.Models.Events;
	using EventsSystem.Data.Models;

	public class TownResponseModel : IMapFrom<Town>, IHaveCustomMappings
	{
        public int Id { get; set; }

        public string Name { get; set; }

		public int EventsCount { get; set; }

		public List<string> Events { get; set; }

		public void CreateMappings(IConfiguration config)
		{
			config.CreateMap<Town, TownResponseModel>()
					.ForMember(t => t.EventsCount, opts => opts.MapFrom(t => t.Events.Count))
					.ForMember(t => t.Events, opts => opts.MapFrom(t => t.Events.OrderByDescending(e => e.StartDate).ToList().Select(e => e.Name)));
        }
	}
}