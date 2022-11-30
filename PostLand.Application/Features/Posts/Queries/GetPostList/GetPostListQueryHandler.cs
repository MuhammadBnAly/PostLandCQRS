using AutoMapper;
using MediatR;
using PostLand.Application.Contracts;

namespace PostLand.Application.Features.Posts.Queries.GetPostList
{
    internal class GetPostListQueryHandler 
        : IRequestHandler<GetPostListQuery, List<GetPostListViewModel>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostListQueryHandler(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        //
        public async Task<List<GetPostListViewModel>> 
            Handle(GetPostListQuery request, CancellationToken cancellation)
        {
            var allPosts = await _postRepository.GetAllPostsAsync(true);
            return _mapper.Map<List<GetPostListViewModel>>(allPosts);
        }
    }
}
