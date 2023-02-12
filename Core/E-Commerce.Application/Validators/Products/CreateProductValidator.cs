using System.ComponentModel;
using E_Commerce.Application.Contstants;
using E_Commerce.Application.ViewModels.Products;
using FluentValidation;
using FluentValidation.Validators;

namespace E_Commerce.Application.Validators.Products;

public class CreateProductValidator: AbstractValidator<VmProductCreate>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(Message.NotNull)
            .MaximumLength(150)
            .MinimumLength(5)
            .WithMessage(Message.CharacterLength);
        RuleFor(p => p.Stock)
            .NotEmpty()
            .NotNull()
            .WithMessage(Message.NumberNotNull)
            .Must(m => m >= 0)
            .WithMessage(Message.GreaterZero);
        
        RuleFor(p => p.Price)
            .NotEmpty()
            .NotNull()
            .WithMessage(Message.NumberNotNull)
            .Must(m => m >= 0)
            .WithMessage(Message.GreaterZero);
    }
}