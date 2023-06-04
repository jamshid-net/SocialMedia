namespace SocialMedia.Application.Validations.CommentValidation;
public class CreateCommentValidation:AbstractValidator<CreateCommentCommand>
{
    public CreateCommentValidation()
    {
        RuleFor(x => x.CommentText).NotEmpty().WithMessage("Comment is required!");
        RuleFor(x => x.PostId).NotNull().NotEmpty().WithMessage("Post is required!");
    }
}
