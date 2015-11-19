namespace EventsSystem.Api.Models.Categories
{
	using System.ComponentModel.DataAnnotations;

	using EventsSystem.Common.Constants;
	
	public class CategorySaveModel
	{
		[Required]
		[MinLength(ValidationConstants.MinCategoryNameLenght)]
		[MaxLength(ValidationConstants.MaxCategoryNameLenght)]
		public string Name { get; set; }
	}
}