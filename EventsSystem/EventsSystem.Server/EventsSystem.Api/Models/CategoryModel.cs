using EventsSystem.Api.Infrastructure;
using EventsSystem.Api.Infrastructure.Mapping;
using EventsSystem.Common.Constants;
using EventsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;

namespace EventsSystem.Api.Models
{
	public class CategoryModel : IMapFrom<Category>, IHaveCustomMappings
	{
		private object e;

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