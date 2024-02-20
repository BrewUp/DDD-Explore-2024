﻿using BrewUp.Infrastructure.RabbitMq;
using BrewUp.Shared.ReadModel;
using BrewUp.Warehouses.Facade.Validators;
using BrewUp.Warehouses.Infrastructures.MongoDb;
using BrewUp.Warehouses.Infrastructures.RabbitMq;
using BrewUp.Warehouses.ReadModel.Dtos;
using BrewUp.Warehouses.ReadModel.Queries;
using BrewUp.Warehouses.ReadModel.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Warehouses.Facade;

public static class WarehousesHelper
{
	public static IServiceCollection AddWarehouses(this IServiceCollection services)
	{
		services.AddFluentValidationAutoValidation();
		services.AddValidatorsFromAssemblyContaining<SetAvailabilityValidator>();
		services.AddSingleton<ValidationHandler>();

		services.AddScoped<IWarehousesFacade, WarehousesFacade>();
		services.AddScoped<IAvailabilityService, AvailabilityService>();
		services.AddScoped<IQueries<Availability>, AvailabilityQueries>();

		return services;
	}

	public static IServiceCollection AddWarehousesInfrastructure(this IServiceCollection services, RabbitMqSettings rabbitMqSettings)
	{
		services.AddWarehousesMongoDb();
		services.AddRabbitMqForWarehousesModule(rabbitMqSettings);

		return services;
	}
}