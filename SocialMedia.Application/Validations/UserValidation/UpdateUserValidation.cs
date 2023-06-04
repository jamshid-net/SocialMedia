namespace SocialMedia.Application.Validations.UserValidation;
public class UpdateUserValidation:AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidation()
           => RuleFor(x => x.Id)
             .NotNull().NotEmpty().WithMessage("Id is required for update");
    
}
