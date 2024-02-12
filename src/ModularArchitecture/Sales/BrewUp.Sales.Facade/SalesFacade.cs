using BrewUp.Sales.ReadModel.Services;
using BrewUp.Sales.SharedKernel.Commands;
using BrewUp.Sales.SharedKernel.CustomTypes;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.Entities;
using Muflone.Persistence;

namespace BrewUp.Sales.Facade;

public sealed class SalesFacade(IServiceBus serviceBus,
	ISalesQueryService salesQueryService) : ISalesFacade
{
	public async Task<string> CreateOrderAsync(SalesOrderJson body, CancellationToken cancellationToken)
	{
		if (body.SalesOrderId.Equals(string.Empty))
			body = body with { SalesOrderId = Guid.NewGuid().ToString() };

		CreateSalesOrder command = new(new SalesOrderId(new Guid(body.SalesOrderId)),
						Guid.NewGuid(), new SalesOrderNumber(body.SalesOrderNumber), new OrderDate(body.OrderDate),
									new CustomerId(body.CustomerId), new CustomerName(body.CustomerName), body.Rows);
		await serviceBus.SendAsync(command, cancellationToken);

		return body.SalesOrderId;
	}

	public async Task<PagedResult<SalesOrderJson>> GetOrdersAsync(CancellationToken cancellationToken)
	{
		return await salesQueryService.GetSalesOrdersAsync(0, 30, cancellationToken);
	}
}