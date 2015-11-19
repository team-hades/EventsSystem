namespace EventsSystem.Api.Models.Categories
{
	using System.ComponentModel.DataAnnotations;
	using System.Collections.Generic;
	using System.Linq;

	using AutoMapper;

	using EventsSystem.Api.Infrastructure.Mapping;
	using EventsSystem.Common.Constants;
	using EventsSystem.Data.Models;
	
	public class CategoryResponseModel : IMapFrom<Category>, IHaveCustomMappings
	{
		[Required]
		[MinLength(ValidationConstants.MinCategoryNameLenght)]
		[MaxLength(ValidationConstants.MaxCategoryNameLenght)]
		public string Name { get; set; }

		public int CountOfEvents { get; set; }

		public List<string> Events { get; set; }

		public void CreateMappings(IConfiguration config)
		{
			config.CreateMap<Category, CategoryResponseModel>()
				.ForMember(c => c.CountOfEvents, opts => opts.MapFrom(c => c.Events.Count))
				.ForMember(c => c.Events, opts => opts.MapFrom(c => c.Events.OrderByDescending(e => e.StartDate).ToList().Select(e => e.Name)));
		}
	}
}