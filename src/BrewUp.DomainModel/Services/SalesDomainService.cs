﻿using BrewUp.DomainModel.Entities.Sales;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.ReadModel;

namespace BrewUp.DomainModel.Services;

public sealed class SalesDomainService(IRepository repository) : ISalesDomainService
{
	public async Task CreateSalesOrderAsync(SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber, OrderDate orderDate,
		CustomerId customerId, CustomerName customerName, IEnumerable<SalesOrderRowJson> rows, CancellationToken cancellationToken)
	{
		var aggregate = SalesOrder.CreateSalesOrder(salesOrderId, salesOrderNumber, orderDate, customerId, customerName, rows);

		await repository.InsertAsync(aggregate.MapToReadModel(), cancellationToken);
	}
}