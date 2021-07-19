using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRMQ
{
    public class RabbitMQPersistentConnection : IDefaultPersistentConnection
    {
        private IFactory factory;
        private IConnection connection;
        public RabbitMQPersistentConnection(IFactory factory) 
        {
            this.factory = factory;
            
        }
        public bool IsConnected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IModel GetConnection()
        {
            throw new NotImplementedException();
        }

        private IConnection Connected() 
        {
            return 
        }
    }
}
