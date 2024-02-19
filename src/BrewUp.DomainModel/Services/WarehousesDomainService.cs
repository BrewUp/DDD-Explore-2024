﻿using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.ReadModel;

namespace BrewUp.DomainModel.Services;

public sealed class WarehousesDomainService(IRepository repository) : IWarehousesDomainService
{
	public async Task UpdateAvailabilityDueToProductionOrderAsync(BeerId beerId, BeerName beerName, Quantity quantity,
		CancellationToken cancellationToken)
	{
		var aggregate = Entities.Warehouses.Availability.CreateAvailability(beerId, beerName, quantity);
		await repository.InsertAsync(aggregate.MapToReadModel(), cancellationToken);
	}
}