using FluentValidation.Results;
using Haze.Core.Domain.Events;
using MediatR;
using System;

namespace Haze.Core.Domain.Commands
{
    public abstract class Command : Message, IRequest<bool>
    {
        public DateTime Timestamp { get; }
        public ValidationResult ValidationResult { get; set; }

        protected Command(Guid aggregateId) : base(aggregateId)
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}