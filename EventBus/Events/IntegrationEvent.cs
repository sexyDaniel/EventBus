using System;

namespace EventBus.Events
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
