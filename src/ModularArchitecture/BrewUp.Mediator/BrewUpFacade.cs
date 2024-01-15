using BrewUp.Sales.Facade;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;
using BrewUp.Shared.Helpers;
using BrewUp.Warehouses.Facade;

namespace BrewUp.Mediator;

public class BrewUpFacade(ISalesFacade salesFacade, IWarehousesFacade warehouseFacade) : IBrewUpFacade
{
	public async Task<string> CreateOrderAsync(SalesOrderJson body, CancellationToken cancellationToken)
	{
		var availability = await warehouseFacade.GetAvailabilityAsync(body.Rows.ToBeerAvailabilities(), cancellationToken);
		return await salesFacade.CreateOrderAsync(body, cancellationToken);
	}

	public Task<PagedResult<SalesOrderJson>> GetOrdersAsync(CancellationToken cancellationToken)
	{
		return salesFacade.GetOrdersAsync(cancellationToken);
	}
}