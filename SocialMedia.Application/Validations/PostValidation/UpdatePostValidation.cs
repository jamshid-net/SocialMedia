namespace SocialMedia.Application.Validations.PostValidation;
public class UpdatePostValidation:AbstractValidator<UpdatePostCommand>
{
    public UpdatePostValidation()
           => RuleFor(x => x.PostId)
              .NotNull().WithMessage("Id is required for update!");
    
    
}
