using EventBusLib.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusLib.EventBus.Abstractions
{
    public interface IEventBus
    {
        void Publish(IntegrationEvent @event);
        void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler;

        void Unsubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler;
    }
}
