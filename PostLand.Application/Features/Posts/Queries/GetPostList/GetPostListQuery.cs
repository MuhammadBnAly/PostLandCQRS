using MediatR;

namespace PostLand.Application.Features.Posts.Queries.GetPostList
{
    public class GetPostListQuery : IRequest<List<GetPostListViewModel>>
    {
        // It has not any implementation because we do not want to bring everything
    }
}
