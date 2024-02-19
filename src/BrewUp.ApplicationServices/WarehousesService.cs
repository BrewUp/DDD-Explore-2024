using BrewUp.DomainModel.Services;
using BrewUp.ReadModel.Warehouses.Services;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.Entities;

namespace BrewUp.ApplicationServices
{
	public class WarehousesService(IWarehousesDomainService warehousesDomainService, IAvailabilityQueryService availabilityQueryService) : IWarehousesService
	{
		public async Task<PagedResult<BeerAvailabilityJson>> GetAvailabilityAsync(Guid beerId, CancellationToken cancellationToken)
		{
			return await availabilityQueryService.GetAvailabilityAsync(beerId, cancellationToken);
		}

		public async Task SetAvailabilityAsync(SetAvailabilityJson availability, CancellationToken cancellationToken)
		{
			await warehousesDomainService.UpdateAvailabilityDueToProductionOrderAsync(
				new BeerId(new Guid(availability.BeerId)), new BeerName(availability.BeerName), availability.Quantity,
				cancellationToken);
		}
	}

	public interface IWarehousesService
	{
		Task<PagedResult<BeerAvailabilityJson>> GetAvailabilityAsync(Guid beerId, CancellationToken cancellationToken);
		Task SetAvailabilityAsync(SetAvailabilityJson availability, CancellationToken cancellationToken);
	}
}
