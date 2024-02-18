using BrewUp.Warehouses.ReadModel.EventHandlers;
using BrewUp.Warehouses.ReadModel.Services;
using BrewUp.Warehouses.SharedKernel.Events;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Events;

public sealed class AvailabilityUpdatedDueToProductionOrderConsumer : DomainEventsConsumerBase<AvailabilityUpdatedDueToProductionOrder>
{
	protected override IEnumerable<IDomainEventHandlerAsync<AvailabilityUpdatedDueToProductionOrder>> HandlersAsync { get; }

	public AvailabilityUpdatedDueToProductionOrderConsumer(IAvailabilityService availabilityService, IEventBus eventBus,
		IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory) : base(connectionFactory, loggerFactory)
	{
		HandlersAsync = new List<DomainEventHandlerAsync<AvailabilityUpdatedDueToProductionOrder>>
		{
			new AvailabilityUpdatedDueToProductionOrderEventHandler(loggerFactory, availabilityService)
		};
	}
}