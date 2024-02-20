﻿using BrewUp.Sales.Domain.Entities;
using BrewUp.Sales.SharedKernel.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Sales.Domain.CommandHandlers;

public sealed class UpdateAvailabilityDueToWarehousesNotificationCommandHandler : CommandHandlerBaseAsync<UpdateAvailabilityDueToWarehousesNotification>
{
	public UpdateAvailabilityDueToWarehousesNotificationCommandHandler(IRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
	{
	}

	public override async Task ProcessCommand(UpdateAvailabilityDueToWarehousesNotification command,
		CancellationToken cancellationToken = default)
	{
		try
		{
			var aggregate = await Repository.GetByIdAsync<Availability>(command.BeerId.Value);
			if (aggregate == null || aggregate.Id is null)
			{
				aggregate = Availability.CreateAvailability(command.BeerId, command.BeerName, command.Quantity, command.MessageId);
			}
			else
			{
				aggregate.UpdateAvailability(command.Quantity, command.MessageId);
			}

			await Repository.SaveAsync(aggregate, Guid.NewGuid());
		}
		catch (Exception e)
		{
			// I'm lazy ... I should raise an event here
			Console.WriteLine(e);
			throw;
		}
	}
}