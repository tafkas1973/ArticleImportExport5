using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Office4U.Articles.ImportExport.Api.Controllers.DTOs.Article;
using Office4U.Articles.ImportExport.Api.Data.Repositories.Interfaces;
using Office4U.Articles.ImportExport.Api.Entities;
using Office4U.Articles.ImportExport.Api.Extensions;
using Office4U.Articles.ImportExport.Api.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Office4U.Articles.ImportExport.Api.Controllers
{
    [Authorize(Policy = "RequireManageArticlesRole")]
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ArticlesController(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetArticles(
            [FromQuery] ArticleParams articleParams)
        {
            var articles = await _unitOfWork.ArticleRepository.GetArticlesAsync(articleParams);

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

        [HttpGet("{id}", Name = "GetArticle")]
        public async Task<ActionResult<ArticleDto>> GetArticle(int id)
        {
            var article = await _unitOfWork.ArticleRepository.GetArticleByIdAsync(id);

            var articleToReturn = _mapper.Map<ArticleDto>(article);

            return articleToReturn;
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleForCreationDto newArticleDto)
        {
            var newArticle = _mapper.Map<Article>(newArticleDto);

            _unitOfWork.ArticleRepository.Add(newArticle);

            if (await _unitOfWork.Commit())
            {
                var articleToReturn = _mapper.Map<ArticleForReturnDto>(newArticle);
                return CreatedAtRoute("GetArticle", new { id = newArticle.Id }, articleToReturn);
            }

            return BadRequest("Failed to create article");
        }

        [HttpPut]
        // TODO: restful: also specify id in parm list?
        public async Task<ActionResult> UpdateArticle(ArticleUpdateDto articleUpdateDto)
        {
            var article = await _unitOfWork.ArticleRepository.GetArticleByIdAsync(articleUpdateDto.Id);

            _mapper.Map(articleUpdateDto, article);

            _unitOfWork.ArticleRepository.Update(article);

            if (await _unitOfWork.Commit()) return NoContent();

            return BadRequest("Failed to update article");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var articleToDelete = await _unitOfWork.ArticleRepository.GetArticleByIdAsync(id);

            _unitOfWork.ArticleRepository.Delete(articleToDelete);

            if (await _unitOfWork.Commit())
                return Ok();

            return BadRequest("Failed to delete article");
        }
    }
}