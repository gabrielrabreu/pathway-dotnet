using Core.Domain.Events;
using MediatR;
using System;

namespace Core.Domain.Notifications
{
    public class DomainNotification : Message, INotification
    {
        public string Key { get; }
        public string Value { get; }

        public DomainNotification(string key, string value) : base(Guid.NewGuid())
        {
            Key = key;
            Value = value;
        }
    }
}
