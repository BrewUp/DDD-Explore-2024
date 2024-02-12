using BrewUp.Shared.Contracts;

namespace BrewUp.Warehouses.Facade;

public interface IWarehousesFacade
{
	Task<object> GetAvailabilityAsync(IEnumerable<BeerAvailabilityJson> beers, CancellationToken cancellationToken);
}