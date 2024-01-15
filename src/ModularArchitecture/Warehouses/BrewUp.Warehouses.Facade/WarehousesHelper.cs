using BrewUp.Warehouses.Domain;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Warehouses.Facade;

public static class WarehousesHelper
{
	public static IServiceCollection AddWarehouses(this IServiceCollection services)
	{
		services.AddFluentValidationAutoValidation();

		services.AddScoped<IWarehousesFacade, WarehousesFacade>();
		services.AddScoped<IWarehousesDomainService, WarehousesDomainService>();
		//services.AddScoped<ISalesQueryService, SalesQueryService>();
		//services.AddScoped<IQueries<SalesOrder>, SalesOrderQueries>();

		return services;
	}

	public static IServiceCollection AddWarehousesInfrastructure(this IServiceCollection services)
	{
		//services.AddWarehuosesMongoDb();

		return services;
	}
}