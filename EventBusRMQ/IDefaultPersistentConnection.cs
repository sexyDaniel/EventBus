using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRMQ
{
    public interface IDefaultPersistentConnection
    {
        bool IsConnected { get; set; }
        IModel GetConnection();
    }
}
