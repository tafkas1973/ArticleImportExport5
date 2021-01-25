using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Office4U.Articles.ImportExport.Api.Controllers;
using Office4U.Articles.ImportExport.Api.DTOs;
using Office4U.Articles.ImportExport.Api.Entities;
using Office4U.Articles.ImportExport.Api.Helpers;
using Office4U.Articles.ImportExport.Api.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Office4U.Articles.ImportExport.Api.Tests.Controllers
{
    public class ArticlesControllerTests : ControllerTestsBase
    {
        [Test]
        public async Task GetArticles_WithEmptyParams_ReturnsArticleListWithFiveItems()
        {
            // arrange
            var articleRepositoryMock = new Mock<IArticleRepository>();
            var articleParams = new ArticleParams();
            var testArticles = new List<Article>() {
                new Article() { Id = 1, Code = "Article1", Name1="first article", SupplierId = "sup1", SupplierReference="sup ref 1", Unit="ST", PurchasePrice = 50.00M},
                new Article() { Id = 2, Code = "Article2", Name1="second article", SupplierId = "sup1", SupplierReference="sup ref 2", Unit="ST", PurchasePrice = 100.00M},
                new Article() { Id = 3, Code = "Article3", Name1="third article", SupplierId = "sup2", SupplierReference="sup ref 10", Unit="ST", PurchasePrice = 150.00M}
            }.AsEnumerable();
            var articlesPagedList = new PagedList<Article>(items: testArticles, count: 3, pageNumber: 1, pageSize: 10);
            articleRepositoryMock
                .Setup(m => m.GetArticlesAsync(articleParams))
                .ReturnsAsync(articlesPagedList);

            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfiles>()));


            var articlesController = new ArticlesController(articleRepositoryMock.Object, mapper) { ControllerContext = TestControllerContext };

            // act
            var result = await articlesController.GetArticles(articleParams);

            // assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.GetType(), Is.EqualTo(typeof(ActionResult<IEnumerable<ArticleDto>>)));
            Assert.That(result.Result.GetType(), Is.EqualTo(typeof(OkObjectResult)));
            Assert.That(((ObjectResult)result.Result).Value.GetType(), Is.EqualTo(typeof(List<ArticleDto>)));
            Assert.That(((List<ArticleDto>)((ObjectResult)result.Result).Value).Count, Is.EqualTo(3));
        }
    }
}
