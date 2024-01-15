using Haze.Anything.Domain.Entities;
using Haze.Core.Domain.Commands;
using System;

namespace Haze.Anything.Domain.Commands.FulanoCommands
{
    public abstract class FulanoCommand<T> : Command
            where T : FulanoCommand<T>
    {
        public Fulano Entity { get; set; }

        protected FulanoCommand(Guid aggregateId)
            : base(aggregateId) { }
    }
}