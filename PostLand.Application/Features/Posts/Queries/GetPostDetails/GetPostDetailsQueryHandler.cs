using AutoMapper;
using MediatR;
using PostLand.Application.Contracts;

namespace PostLand.Application.Features.Posts.Queries.GetPostDetails
{
    internal class GetPostDetailsQueryHandler : IRequestHandler<GetPostDeatailsQuery, GetPostDetailsViewModel>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public GetPostDetailsQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<GetPostDetailsViewModel>
            Handle(GetPostDeatailsQuery reqest, CancellationToken cancellation)
        {
            var post = _postRepository.GetPostByIdAsync(reqest.PostId, true);
            return _mapper.Map<GetPostDetailsViewModel>(post);
        }


    }
}
