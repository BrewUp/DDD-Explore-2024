using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using BrewUp.Warehouses.Domain;
using BrewUp.Warehouses.SharedKernel.Contracts;

namespace BrewUp.Warehouses.Facade;

public sealed class WarehousesFacade(IWarehousesDomainService warehousesDomainService) : IWarehousesFacade
{
	public Task<object> GetAvailabilityAsync(IEnumerable<BeerAvailabilityJson> beers, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public async Task SetAvailabilityAsync(SetAvailabilityJson availability, CancellationToken cancellationToken)
	{
		await warehousesDomainService.UpdateAvailabilityDueToProductionOrderAsync(
			new BeerId(new Guid(availability.BeerId)), new BeerName(availability.BeerName), availability.Quantity,
			cancellationToken);
	}
}