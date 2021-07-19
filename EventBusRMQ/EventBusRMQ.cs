using EventBus.Abstractions;
using EventBus.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace EventBusRMQ
{
    public class EventBusRMQ : IEventBus
    {
        private readonly string queueName;
        private readonly IModel consumerChanel;
        private readonly IDefaultPersistentConnection persistentConnection;
        const string exchangeName = "EventExchange";

        public EventBusRMQ(string queueName,IDefaultPersistentConnection persistentConnection) 
        {
            this.queueName = queueName;
            this.persistentConnection = persistentConnection;
            consumerChanel = CreateConsumer();
        }
        public void Publish(IntegrationEvent @event)
        {
            var eventName = @event.GetType().Name;

            using var chanel = persistentConnection.CreateModel();
            chanel.ExchangeDeclare(exchangeName, ExchangeType.Direct);

            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);
            chanel.BasicPublish(
                exchange: exchangeName,
                routingKey: eventName,
                body:body);
        }   

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler
        {
            var eventName = typeof(T).Name;

            using var chanel = persistentConnection.CreateModel();

            chanel.QueueBind(
                queue:queueName,
                exchange:exchangeName,
                routingKey:eventName);

            StartConsumer<T, TH>();
        }

        public void Unsubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler
        {
            throw new NotImplementedException();
        }

        private IModel CreateConsumer() 
        {
            var chanel = persistentConnection.CreateModel();

            chanel.ExchangeDeclare(exchangeName,ExchangeType.Direct);

            chanel.QueueDeclare(
                queue:queueName,
                durable:true,
                exclusive:false,
                autoDelete:false);

            return chanel;
        }
        private void StartConsumer<T,TH>() 
        {
            var consumer = new EventingBasicConsumer(consumerChanel);

            consumer.Received += (object sender, BasicDeliverEventArgs args) =>
            {
                var body = args.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());

                var @event = JsonConvert.DeserializeObject<T>(message);
                dynamic handler = Activator.CreateInstance(typeof(TH));

                handler.Handle(@event);
            };
        }
    }
}
