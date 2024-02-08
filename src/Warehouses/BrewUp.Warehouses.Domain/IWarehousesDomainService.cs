namespace BrewUp.Warehouses.Domain;

public interface IWarehousesDomainService
{
	Task UpdateAvailabilityDueToSalesOrderAsync();
}