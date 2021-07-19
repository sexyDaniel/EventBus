using System;
using RabbitMQ.Client;

namespace EventBusRMQ
{
    public class RabbitMQPersistentConnection : IDefaultPersistentConnection
    {
        private IConnectionFactory factory;
        private IConnection connection;
        public RabbitMQPersistentConnection(IConnectionFactory factory) 
        {
            this.factory = factory;
            Connected();
        }

        public IModel CreateModel()
        {
            return connection.CreateModel();
        }

        private void  Connected() 
        {
            connection = factory.CreateConnection();
        }

    }
}
