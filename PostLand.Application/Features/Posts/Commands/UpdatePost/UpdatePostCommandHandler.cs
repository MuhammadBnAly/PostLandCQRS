using AutoMapper;
using MediatR;
using PostLand.Application.Contracts;
using PostLand.Domain;

namespace PostLand.Application.Features.Posts.Commands.UpdatePost
{
    internal class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IAsyncRepository<Post> _repository;
        private readonly IMapper _mapper;
        public UpdatePostCommandHandler(IAsyncRepository<Post> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> 
            Handle(UpdatePostCommand request, CancellationToken cancellation)
        {
            Post post = _mapper.Map<Post>(request);
            await _repository.UpdateAsync(post);
            return Unit.Value;
        }

    }
}
