using BrewUp.Warehouses.Domain.Entities;
using BrewUp.Warehouses.SharedKernel.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Warehouses.Domain.CommandHandlers;

public sealed class UpdateAvailabilityDueToProductionOrderCommandHandler : CommandHandlerBaseAsync<UpdateAvailabilityDueToProductionOrder>
{
	public UpdateAvailabilityDueToProductionOrderCommandHandler(IRepository repository, ILoggerFactory loggerFactory) :
		base(repository, loggerFactory)
	{
	}

	public override async Task ProcessCommand(UpdateAvailabilityDueToProductionOrder command, CancellationToken cancellationToken = default)
	{
		var aggregate = Availability.CreateAvailability(command.BeerId, command.BeerName, command.Quantity, command.MessageId);
		await Repository.SaveAsync(aggregate, Guid.NewGuid());
	}
}