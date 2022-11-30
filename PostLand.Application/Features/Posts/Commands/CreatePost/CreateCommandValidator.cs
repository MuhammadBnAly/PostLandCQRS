using FluentValidation;

namespace PostLand.Application.Features.Posts.Commands.CreatePost
{
    internal class CreateCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
            RuleFor(p => p.Content)
                .NotNull()
                .NotEmpty();
        }
    }
}
