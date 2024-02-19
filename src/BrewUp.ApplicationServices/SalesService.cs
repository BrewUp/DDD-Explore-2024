using BrewUp.DomainModel.Services;
using BrewUp.ReadModel.Sales.Services;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.Entities;

namespace BrewUp.ApplicationServices
{
	public class SalesService(ISalesDomainService salesDomainService,
	ISalesQueryService salesQueryService) : ISalesService
	{
		public async Task<string> CreateOrderAsync(SalesOrderJson body, CancellationToken cancellationToken)
		{
			if (body.SalesOrderId.Equals(string.Empty))
				body = body with { SalesOrderId = Guid.NewGuid().ToString() };

			await salesDomainService.CreateSalesOrderAsync(new SalesOrderId(new Guid(body.SalesOrderId)),
				new SalesOrderNumber(body.SalesOrderNumber), new OrderDate(body.OrderDate),
				new CustomerId(body.CustomerId), new CustomerName(body.CustomerName),
				body.Rows, cancellationToken);

			return body.SalesOrderId;
		}

		public async Task<PagedResult<SalesOrderJson>> GetOrdersAsync(CancellationToken cancellationToken)
		{
			return await salesQueryService.GetSalesOrdersAsync(0, 30, cancellationToken);
		}
	}
}
