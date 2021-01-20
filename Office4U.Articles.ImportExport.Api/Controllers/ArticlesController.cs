using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Office4U.Articles.ImportExport.Api.Interfaces;
using AutoMapper;
using Office4U.Articles.ImportExport.Api.DTOs;

namespace Office4U.Articles.ImportExport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _articleRespository;
        private readonly IMapper _mapper;
        public ArticlesController(
            IArticleRepository articleRespository,
            IMapper mapper)
        {
            _mapper = mapper;
            _articleRespository = articleRespository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetArticles()
        {
            var articles = await _articleRespository.GetArticlesAsync();

            var articlesToReturn = _mapper.Map<IEnumerable<ArticleDto>>(articles);

            return Ok(articlesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDto>> GetArticle(int id)
        {
            var article = await _articleRespository.GetArticleByIdAsync(id);

            var articleToReturn = _mapper.Map<ArticleDto>(article);

            return articleToReturn;
        }
    }
}