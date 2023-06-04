namespace SocialMedia.Application.Validations.CommentValidation;
public class UpdateCommentValidation:AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentValidation()
    {
        RuleFor(x => x.CommentId).NotEmpty().NotNull().WithMessage("Comment id is required!");
        RuleFor(x => x.CommentText).NotEmpty().NotNull().WithMessage("comment text is required for update!");
    }
}
