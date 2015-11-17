namespace EventsSystem.Api.Models.Comments
{
    using System;
    using AutoMapper;
    using EventsSystem.Api.Infrastructure.Mapping;
    using EventsSystem.Data.Models;

    public class CommmentsResponseModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public int EventId { get; set; }

        public string UserName { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Comment, CommmentsResponseModel>()
                .ForMember(c => c.UserName, opts => opts.MapFrom(c => c.Author.FirstName));
        }
    }
}