using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Office4U.Articles.ImportExport.Api.DTOs;
using Office4U.Articles.ImportExport.Api.Extensions;
using Office4U.Articles.ImportExport.Api.Helpers;
using Office4U.Articles.ImportExport.Api.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Office4U.Articles.ImportExport.Api.Controllers
{
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDto>> GetArticle(int id)
        {
            var article = await _unitOfWork.ArticleRepository.GetArticleByIdAsync(id);

            var articleToReturn = _mapper.Map<ArticleDto>(article);

            return articleToReturn;
        }

        [HttpPut]
        // TODO: restful: also specify id in parm list?
        public async Task<ActionResult> UpdateArticle(ArticleUpdateDto articleUpdateDto)
        {
            var article = await _unitOfWork.ArticleRepository.GetArticleByIdAsync(articleUpdateDto.Id);

            _mapper.Map(articleUpdateDto, article);

            _unitOfWork.ArticleRepository.Update(article);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update article");
        }
    }
}