using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Office4U.Articles.ImportExport.Api.Interfaces;
using AutoMapper;
using Office4U.Articles.ImportExport.Api.DTOs;
using Office4U.Articles.ImportExport.Api.Helpers;
using Office4U.Articles.ImportExport.Api.Extensions;

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
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetArticles(
            [FromQuery] ArticleParams articleParams)
        {
            var articles = await _articleRespository.GetArticlesAsync(articleParams);

            var articlesToReturn = _mapper.Map<IEnumerable<ArticleDto>>(articles);

            // users is of type PagedList<User> 
            // (inherits List, so it's a List of Users plus Pagination info)
            Response.AddPaginationHeader(
                articles.CurrentPage,
                articles.PageSize,
                articles.TotalCount,
                articles.TotalPages);

            return Ok(articlesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDto>> GetArticle(int id)
        {
            var article = await _articleRespository.GetArticleByIdAsync(id);

            var articleToReturn = _mapper.Map<ArticleDto>(article);

            return articleToReturn;
        }

        [HttpPut]
        // TODO: restful: also specify id in parm list?
        public async Task<ActionResult> UpdateArticle(ArticleUpdateDto articleUpdateDto)
        {
            var article = await _articleRespository.GetArticleByIdAsync(articleUpdateDto.Id);

            _mapper.Map(articleUpdateDto, article);

            _articleRespository.Update(article);

            if (await _articleRespository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }
    }
}