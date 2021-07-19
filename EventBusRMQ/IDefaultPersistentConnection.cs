using RabbitMQ.Client;

namespace EventBusRMQ
{
    public interface IDefaultPersistentConnection
    {
        IModel CreateModel();
    }
}
