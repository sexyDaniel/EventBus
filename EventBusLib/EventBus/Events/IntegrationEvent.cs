using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusLib.EventBus.Events
{
    public class IntegrationEvent
    {
        public DateTime Date { get; set; }
        public IntegrationEvent() 
        {
            Date = DateTime.UtcNow;
        }
    }
}
