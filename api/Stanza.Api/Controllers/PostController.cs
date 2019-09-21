using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stanza.Api.Models;
using System.Linq;

namespace Stanza.Api.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly StanzaContext _context;

        public PostController(StanzaContext context)
        {
            _context = context;

            if (_context.Posts.Count() == 0)
            {
                _context.Posts.Add(new Post
                {
                    Id = 1,
                    Content = "Hello, world!"
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostAsync(long id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
                return NotFound();
            
            return post;
        }

        [HttpPost]
        public async Task<ActionResult<Post>> PostAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPostAsync), new { id = post.Id },
                post);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> PutAsync(long id, Post post)
        {
            if (id != post.Id)
                return BadRequest();
            
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
                return NotFound();

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}