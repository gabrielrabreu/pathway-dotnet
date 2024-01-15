using MediatR;
using System;

namespace Haze.Core.Domain.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}