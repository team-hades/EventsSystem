namespace EventsSystem.Api.Models.Events
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using AutoMapper;

    using EventsSystem.Api.Infrastructure.Mapping;
    using Comments;
    using EventsSystem.Data.Models;

    public class EventResponseModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

		public string ShortDescrtiption { get; set; }

		public bool IsPrivate { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

        public string Town { get; set; }

        public string Category { get; set;}

        public float Rating { get; set; }

        public object CommentsCount { get; set; }

		public IEnumerable<string> Tags { get; set; }

		public IEnumerable<CommmentsResponseModel> Comments { get; set; }

		public void CreateMappings(IConfiguration config)
        {
			config.CreateMap<Event, EventResponseModel>()
				.ForMember(e => e.CommentsCount, opts => opts.MapFrom(c => c.Comments.Count))
				.ForMember(e => e.Town, opts => opts.MapFrom(t => t.Town.Name))
				.ForMember(e => e.Category, opts => opts.MapFrom(t => t.Category.Name))
				.ForMember(e => e.Tags, opts => opts.MapFrom(e => e.Tags.Select(t => t.Name)))
				.ForMember(e => e.Comments, opts => opts.MapFrom(t => t.Comments))
                .ForMember(e=> e.Rating, opts => opts.MapFrom(r => r.Ratings.Select(re => re.Value).Average()));
        }
    }
}