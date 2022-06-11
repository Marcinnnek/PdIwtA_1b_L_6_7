﻿using FluentValidation;

namespace PdIwtA_1b.ASP.DTOs.Validators
{
    public class AddProductDTOValidator: AbstractValidator<AddProductDTO>
    {
        public AddProductDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.IsAvailable).NotEmpty();
        }
    }
}
