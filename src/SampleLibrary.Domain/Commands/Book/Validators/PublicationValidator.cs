﻿using System;
using FluentValidation;
using SampleLibrary.Domain.Tests.Entities.Validators.Entities.ValueObjects;

namespace SampleLibrary.Domain.Commands.Book.Validators
{
    public class PublicationCommandValidator : AbstractValidator<PublicationCommand>
    {
        public PublicationCommandValidator()
        {
            ValidateYear();
            ValidateEdition();
        }

        private void ValidateEdition()
        {
           RuleFor(publication => publication.Edition)
               .Must(edition => edition > 0)
               .WithSeverity(Severity.Error)
               .WithMessage("Edition must be higher than 0.");
        }

        private void ValidateYear()
        {
            RuleFor(publication => publication.Year)
                .Must(year => year <= DateTime.Today.Year)
                .WithSeverity(Severity.Error)
                .WithMessage("Year of publication can't be higher than current year.");
        }
    }
}