﻿using RestAPI.Domain.Validators.CategoryValidators;
using System;

namespace RestAPI.Domain.Commands.CategoryCommands
{
    public class DeleteCategoryCommand : Command
    {
        public DeleteCategoryCommand(Guid aggregateId) : base(aggregateId) { }

        public override bool IsValid()
        {
            ValidationResult = new DeleteCategoryCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
