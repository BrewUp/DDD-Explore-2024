﻿namespace BrewUp.Rest.Modules;

public class WarehousesModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 0;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder) => builder.Services;

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) => endpoints;
}