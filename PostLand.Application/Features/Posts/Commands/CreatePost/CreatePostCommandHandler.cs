using AutoMapper;
using MediatR;
using PostLand.Application.Contracts;
using PostLand.Domain;

namespace PostLand.Application.Features.Posts.Commands.CreatePost
{
    internal class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Guid> 
            Handle(CreatePostCommand request , CancellationToken cancellation)
        {
            // mapping
            Post post = _mapper.Map<Post>(request);
            // Validator
            CreateCommandValidator validations = new CreateCommandValidator();
            var result = await validations.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is Not Valid");
            }
            // Add Post by Repo
            post = await _postRepository.AddAsync(post);
            return post.Id;
        }
        

    }
}
