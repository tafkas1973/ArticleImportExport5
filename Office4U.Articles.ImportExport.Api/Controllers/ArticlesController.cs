using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly DataContext _context;
        public ArticlesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            return await _context.Articles.FindAsync(id);
        }
    }
}