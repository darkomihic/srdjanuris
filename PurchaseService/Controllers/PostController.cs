using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PurchaseService.DTOs.Post;
using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;
using PurchaseService.Data.Interface;

namespace PurchaseService.Controllers
{
    [ApiController]
    [Route("api/purchase/post")]
    [Produces("application/json", "application/xml")]
    public class PostController : Controller
    {
        private readonly IPostRepository postRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public PostController(IPostRepository postRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<PostDTO>> GetPosts()
        {
            List<Post> posts = postRepository.GetPosts();
            if (posts == null || posts.Count == 0)
            {
                return NoContent();
            }


            return Ok(posts);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{postId}")]
        public ActionResult<Post> GetPostById(Guid postId)
        {
            Post post = postRepository.GetPostById(postId);
            if (post == null)
            {
                NoContent();
            }
            return Ok(mapper.Map<PostDTO>(post));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PostConfirmationDTO> CreatePost([FromBody] PostCreationDTO post)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Post mappedPost = mapper.Map<Post>(post);
                PostConfirmation confirmationPost = postRepository.CreatePost(mappedPost);
                postRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetPost", "Post", new { postId = confirmationPost.postId });
                return Created(location, mapper.Map<PostConfirmationDTO>(confirmationPost));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{postId}")]
        public IActionResult DeletePost(Guid postId)
        {
            try
            {
                Post post = postRepository.GetPostById(postId);
                if (post == null)
                {
                    return NotFound();
                }

                postRepository.DeletePost(postId);
                postRepository.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent, "Brisanje je uspesno.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PostDTO> UpdatePost(PostUpdateDTO post)
        {
            try
            {
                Post mappedPost = mapper.Map<Post>(post);
                var updatedPost = postRepository.UpdatePost(mappedPost);
                PostDTO updatedPostDTO = mapper.Map<PostDTO>(updatedPost);
                return Ok(updatedPost);

            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
