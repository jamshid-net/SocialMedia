namespace SocialMedia.Application.Validations.UserValidation;
public class CreateUserValidation:AbstractValidator<CreateUserCommand>
{
    public CreateUserValidation()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required!")
            .MinimumLength(3)
            .MaximumLength(25);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address is required!")
            .EmailAddress().WithMessage("A valid email is required!");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("User name is required!");

        RuleFor(x=> x.Password)
            .NotEmpty().WithMessage("Password is required!")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("Birth date is required!");
            


    }
}
