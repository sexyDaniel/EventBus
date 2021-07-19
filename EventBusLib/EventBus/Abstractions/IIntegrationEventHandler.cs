﻿using EventBusLib.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusLib.EventBus.Abstractions
{
    public interface IIntegrationEventHandler
    {
        void Handler(IntegrationEvent @event);
    }
}
