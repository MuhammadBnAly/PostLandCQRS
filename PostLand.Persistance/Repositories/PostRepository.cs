using Microsoft.EntityFrameworkCore;
using PostLand.Application.Contracts;
using PostLand.Domain;

namespace PostLand.Persistance.Repositories
{
    internal class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(PostDbContext dbContext) : base(dbContext)
        {
        }
        //
        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory)
        {
            List<Post> posts = new List<Post>();
            posts = includeCategory 
                ? await _dbContext.Posts.Include(x => x.Category).ToListAsync()
                : await _dbContext.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPostByIdAsync(Guid id, bool includeCategory)
        {
            Post? post = new Post();
            post = includeCategory
                ? await _dbContext.Posts.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id)
                // : await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
                : await GetByIdAsync(id);
            return post;
        }
    }
}
