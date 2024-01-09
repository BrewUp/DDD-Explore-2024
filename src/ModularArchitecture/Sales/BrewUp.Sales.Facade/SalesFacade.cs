using BrewUp.Sales.Domain;
using BrewUp.Sales.SharedKernel.CustomTypes;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.Entities;

namespace BrewUp.Sales.Facade;

public sealed class SalesFacade(ISalesOrderService salesOrderService) : ISalesFacade
{
	public async Task<string> CreateOrderAsync(SalesOrderJson body, CancellationToken cancellationToken)
	{
		if (body.SalesOrderId.Equals(Guid.Empty))
			body = body with { SalesOrderId = Guid.NewGuid() };

		await salesOrderService.CreateSalesOrderAsync(new SalesOrderId(body.SalesOrderId),
			new SalesOrderNumber(body.SalesOrderNumber), new OrderDate(body.OrderDate),
			new CustomerId(body.CustomerId), new CustomerName(body.CustomerName),
			body.Rows, cancellationToken);

		return body.SalesOrderId.ToString();
	}

	public Task<PagedResult<SalesOrderJson>> GetOrdersAsync(CancellationToken cancellationToken)
	{
		return Task.FromResult(new PagedResult<SalesOrderJson>(Enumerable.Empty<SalesOrderJson>(), 0, 0, 0));
	}
}