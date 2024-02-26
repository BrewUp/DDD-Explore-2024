using BrewUp.ReadModel.Sales.Services;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BrewUp.ApplicationServices
{
	public static class SalesService 
	{	
		public static async Task<Results<Ok<PagedResult<SalesOrderJson>>, NotFound>> HandleGetOrders(ISalesQueryService salesQueryService, CancellationToken cancellationToken)
		{
			var orders = await salesQueryService.GetSalesOrdersAsync(0, 30, cancellationToken);
			return TypedResults.Ok(orders);
		}

		//public static async Task<string> CreateOrderAsync(SalesOrderJson body, ISalesDomainService salesDomainService, CancellationToken cancellationToken)
		//{
		//	if (body.SalesOrderId.Equals(string.Empty))
		//		body = body with { SalesOrderId = Guid.NewGuid().ToString() };

		//	await salesDomainService.CreateSalesOrderAsync(new SalesOrderId(new Guid(body.SalesOrderId)),
		//		new SalesOrderNumber(body.SalesOrderNumber), new OrderDate(body.OrderDate),
		//		new CustomerId(body.CustomerId), new CustomerName(body.CustomerName),
		//		body.Rows, cancellationToken);

		//	return body.SalesOrderId;
		//}
	}
}
