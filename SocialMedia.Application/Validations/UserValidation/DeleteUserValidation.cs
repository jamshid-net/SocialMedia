namespace SocialMedia.Application.Validations.UserValidation;
public class DeleteUserValidation:AbstractValidator<DeleteUserCommand>
{
    public DeleteUserValidation()
        => RuleFor(x=> x.UserId).NotNull().WithMessage("Id is reuqired for delete!");
}

