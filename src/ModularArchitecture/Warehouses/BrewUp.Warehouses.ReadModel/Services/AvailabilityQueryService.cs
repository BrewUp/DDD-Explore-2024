using Microsoft.Extensions.Logging;

namespace BrewUp.Warehouses.ReadModel.Services;

public sealed class AvailabilityQueryService : ServiceBase, IAvailabilityQueryService
{
	public AvailabilityQueryService(ILoggerFactory loggerFactory) : base(loggerFactory)
	{
	}
}