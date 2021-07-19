using EventBus.Events;

namespace EventBus.Abstractions
{
    public interface IIntegrationEventHandler
    {
        void Handle(IntegrationEvent @event);
    }
}
