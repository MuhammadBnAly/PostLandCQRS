using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostLand.Application.Features.Posts.Commands.CreatePost;
using PostLand.Application.Features.Posts.Commands.DeletePost;
using PostLand.Application.Features.Posts.Commands.UpdatePost;
using PostLand.Application.Features.Posts.Queries.GetPostDetails;
using PostLand.Application.Features.Posts.Queries.GetPostList;

namespace PostLand.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name ="getAllPosts")]
        public async Task<ActionResult<List<GetPostListViewModel>>> GetAllPosts()
        {
            var posts = await _mediator.Send(new GetPostListQuery());
            return Ok(posts);
        }

        [HttpGet("{id}", Name ="GetPostById")]
        public async Task<ActionResult<GetPostDetailsViewModel>> GetPostById(Guid id)
        {
            var post = new GetPostDeatailsQuery() { PostId = id };
            return Ok( await _mediator.Send(post));
        }

        [HttpPost(Name ="AddPost")]
        public async Task<ActionResult> Create([FromBody] CreatePostCommand command)
        {
            Guid id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut(Name ="UpdatePost")]
        public async Task<ActionResult> Put([FromBody] UpdatePostCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name ="DeletePost")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletedPost = new DeletePostCommand() { PostId = id };
            await _mediator.Send(deletedPost);
            return NoContent();
        }


    }
}
