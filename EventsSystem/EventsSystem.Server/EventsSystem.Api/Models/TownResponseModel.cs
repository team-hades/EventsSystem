namespace EventsSystem.Api.Models
{
    using Infrastructure.Mapping;
    using Data.Models;

    public class TownResponseModel : IMapFrom<Town>
    {
        public string Name { get; set; }
    }
}