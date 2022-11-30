using PostLand.Application.Features.Posts.Queries.GetPostList;

namespace PostLand.Application.Features.Posts.Queries.GetPostDetails
{
    public class GetPostDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public CategoryDto Category { get; set; }
    }
}
