using FluentValidation.Results;
using Core.Domain.Events;
using MediatR;
using System;

namespace Core.Domain.Commands
{
    public abstract class Command : Message, IRequest<Unit>
    {
        public virtual ValidationResult ValidationResult { get; protected set; }

        protected Command(Guid aggregateId) : base(aggregateId) { }

        public abstract bool IsValid();
    }
}
