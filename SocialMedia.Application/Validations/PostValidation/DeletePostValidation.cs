namespace SocialMedia.Application.Validations.PostValidation;
public class DeletePostValidation:AbstractValidator<DeletePostCommand>
{
    public DeletePostValidation()
           => RuleFor(x => x.PostId)
              .NotNull().WithMessage("Id is required for delete!");
}

