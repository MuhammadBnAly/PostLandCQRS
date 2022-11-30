namespace PostLand.Application.Features.Posts.Queries.GetPostList
{
    public class GetPostListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public CategoryDto Category { get; set; }

    }
}
