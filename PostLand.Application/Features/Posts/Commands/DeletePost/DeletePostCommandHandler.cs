using MediatR;
using PostLand.Application.Contracts;

namespace PostLand.Application.Features.Posts.Commands.DeletePost
{
    internal class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<Unit>
            Handle(DeletePostCommand request, CancellationToken cancellation)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);
            await _postRepository.DeleteAsync(post);
            return Unit.Value;
        }


    }
}
