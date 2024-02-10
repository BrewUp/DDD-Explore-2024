using BrewUp.Shared.Contracts;
using BrewUp.Warehouses.SharedKernel.Contracts;

namespace BrewUp.Warehouses.Facade;

public interface IWarehousesFacade
{
	Task<object> GetAvailabilityAsync(IEnumerable<BeerAvailabilityJson> beers, CancellationToken cancellationToken);
	Task SetAvailabilityAsync(SetAvailabilityJson availability, CancellationToken cancellationToken);
}