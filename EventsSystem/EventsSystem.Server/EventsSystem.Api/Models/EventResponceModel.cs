namespace EventsSystem.Api.Models
{
    using System;
    using Infrastructure.Mapping;
    using Data.Models;
    using Infrastructure;
    using AutoMapper;

    public class EventResponceModel : IMapFrom<Event>, IHaveCustomMappings
    {
		public string Name { get; set; }

		public string ShortDescrtiption { get; set; }

		public bool IsPrivate { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public virtual Town Town { get; set; }

        public object CommentsCount { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Event, EventResponceModel>()
                .ForMember(e => e.CommentsCount, opts => opts.MapFrom(s => s.Comments.Count));
        }
    }
}