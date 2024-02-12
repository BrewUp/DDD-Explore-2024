using BrewUp.Shared.Contracts;

namespace BrewUp.Warehouses.Facade;

public sealed class WarehousesFacade : IWarehousesFacade
{
	public Task<object> GetAvailabilityAsync(IEnumerable<BeerAvailabilityJson> beers, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}