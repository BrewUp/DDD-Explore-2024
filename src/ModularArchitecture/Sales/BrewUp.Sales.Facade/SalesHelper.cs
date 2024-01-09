using BrewUp.Sales.Domain;
using BrewUp.Sales.Facade.Validators;
using BrewUp.Sales.Infrastructures;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Sales.Facade;

public static class SalesHelper
{
	public static IServiceCollection AddSales(this IServiceCollection services)
	{
		services.AddFluentValidationAutoValidation();
		services.AddValidatorsFromAssemblyContaining<SalesOrderValidator>();
		services.AddSingleton<ValidationHandler>();

		services.AddScoped<ISalesFacade, SalesFacade>();
		services.AddScoped<ISalesOrderService, SalesOrderService>();
		//services.AddScoped<IQueries<SalesOrder>, SalesOrderQueries>();

		return services;
	}

	public static IServiceCollection AddSalesInfrastructure(this IServiceCollection services)
	{
		services.AddSalesMongoDb();

		return services;
	}
}