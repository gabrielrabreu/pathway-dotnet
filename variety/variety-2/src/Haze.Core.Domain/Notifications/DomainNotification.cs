using Haze.Core.Domain.Events;
using MediatR;
using System;

namespace Haze.Core.Domain.Notifications
{
    public class DomainNotification : Message, INotification
    {
        public DateTime Timestamp { get; }
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; }
        public string Value { get; }
        public int Version { get; }

        public DomainNotification(string key, string value)
        {
            Timestamp = DateTime.Now;
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}