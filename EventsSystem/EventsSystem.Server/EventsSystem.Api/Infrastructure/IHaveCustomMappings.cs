namespace EventsSystem.Api.Infrastructure
{
	using AutoMapper;

	public interface IHaveCustomMappings
	{
		void CreateMappings(IConfiguration config);
	}
}