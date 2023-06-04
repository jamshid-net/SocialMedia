namespace SocialMedia.Application.Validations.PostValidation;
public class CreatePostValidation:AbstractValidator<CreatePostCommand>
{
    public CreatePostValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required!");
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required");
    }
}
