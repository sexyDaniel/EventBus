using EventBus.Abstractions;
using EventBus.Events;
using System;


namespace EventBusRMQ
{
    public class EventBusRMQ : IEventBus
    {
        private string queueName;
        private IModel consumerChanel;
        private IDefaultPersistentConnection persistentConnection;

        public EventBusRMQ(string queueName,IDefaultPersistentConnection persistentConnection) 
        {
            this.queueName = queueName;
            this.persistentConnection = persistentConnection;
            consumerChanel = CreateConsumer();
        }
        public void Publish(IntegrationEvent @event)
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler
        {
            throw new NotImplementedException();
        }

        private IModel CreateConsumer() 
        {
            
        }
    }
}
