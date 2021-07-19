using EventBus.Events;

namespace EventBus.Abstractions
{
    public interface IIntegrationEventHandler
    {
        void Handler(IntegrationEvent @event);
    }
}
