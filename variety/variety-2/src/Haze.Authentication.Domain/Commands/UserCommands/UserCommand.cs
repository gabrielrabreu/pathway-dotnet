using Haze.Authentication.Domain.Entities;
using Haze.Core.Domain.Commands;
using System;

namespace Haze.Authentication.Domain.Commands.UserCommands
{
    public abstract class UserCommand<T> : Command
            where T : UserCommand<T>
    {
        public User Entity { get; set; }

        protected UserCommand(Guid aggregateId)
            : base(aggregateId) { }
    }
}