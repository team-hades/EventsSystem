namespace EventsSystem.Api.Models.Categories
{
	using System.ComponentModel.DataAnnotations;

	using AutoMapper;

	using EventsSystem.Api.Infrastructure.Mapping;
	using EventsSystem.Common.Constants;
	using EventsSystem.Data.Models;

	public class CategoryModel : IMapFrom<Category>, IHaveCustomMappings
	{
		[Required]
		[MinLength(ValidationConstants.MinCategoryNameLenght)]
		[MaxLength(ValidationConstants.MaxCategoryNameLenght)]
		public string Name { get; set; }

		public int CountOfEvents { get; set; }

		public void CreateMappings(IConfiguration config)
		{
			config.CreateMap<Category, CategoryModel>()
				.ForMember(c => c.CountOfEvents, opts => opts.MapFrom(c => c.Events.Count));
		}
	}
}