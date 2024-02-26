﻿using BrewUp.DomainModel.Services;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BrewUp.ApplicationServices
{
	public static class WarehousesService
	{
		public static async Task<Ok> HandleSetAvailabilities(SetAvailabilityJson body, IWarehousesDomainService warehousesDomainService, CancellationToken cancellationToken)
		{
			await warehousesDomainService.UpdateAvailabilityDueToProductionOrderAsync(new BeerId(new Guid(body.BeerId)), new BeerName(body.BeerName), body.Quantity, cancellationToken);
			return TypedResults.Ok();
		}
	}
}
