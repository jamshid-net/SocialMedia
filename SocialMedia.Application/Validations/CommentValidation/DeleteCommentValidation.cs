namespace SocialMedia.Application.Validations.CommentValidation;
public class DeleteCommentValidation:AbstractValidator<DeleteCommentCommand>
{
    public DeleteCommentValidation()
          => RuleFor(x => x.CommentId).NotNull().NotEmpty().WithMessage("comment id is required for delete!");
}

