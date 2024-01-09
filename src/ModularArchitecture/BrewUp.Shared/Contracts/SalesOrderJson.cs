namespace BrewUp.Shared.Contracts;

public record SalesOrderJson(Guid SalesOrderId, string SalesOrderNumber, Guid CustomerId, string CustomerName, DateTime OrderDate,
	IEnumerable<SalesOrderRowJson> Rows);
