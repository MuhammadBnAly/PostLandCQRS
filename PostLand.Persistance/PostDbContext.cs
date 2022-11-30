using Microsoft.EntityFrameworkCore;
using PostLand.Domain;

namespace PostLand.Persistance
{
    internal class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }

        // ctreating a post
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            var CategoryGuid = Guid.Parse(Guid.NewGuid().ToString());
            var PostGuid = Guid.Parse(Guid.NewGuid().ToString());
            modelBuilder.Entity<Category>().HasData( new Category{
                Id = CategoryGuid,
                Name = "Sports"
            });
            //
            modelBuilder.Entity<Post>().HasData(new Post { 
                Id = PostGuid,
                Title= "Ronaldo will Leave Man United.",
                Content = "Ronaldo will leave Man United after World Cup in Qatar 2022",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8c/Cristiano_Ronaldo_2018.jpg/400px-Cristiano_Ronaldo_2018.jpg",
                CategoryId= CategoryGuid,
            });

        }
    }
}
