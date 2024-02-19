using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;

public interface ISalesService
{
	Task<string> CreateOrderAsync(SalesOrderJson body, CancellationToken cancellationToken);
	Task<PagedResult<SalesOrderJson>> GetOrdersAsync(CancellationToken cancellationToken);
}