using MediatR;

namespace PostLand.Application.Features.Posts.Queries.GetPostDetails
{
    public class GetPostDeatailsQuery : IRequest<GetPostDetailsViewModel>
    {
        public Guid PostId { get; set; }
    }
}
