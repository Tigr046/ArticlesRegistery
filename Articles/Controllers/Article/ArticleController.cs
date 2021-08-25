using ArticleRepository.DTO;
using ArticleRepository.Service;
using Articles.Models;
using Articles.Models.RegisterModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Articles.Controllers.Article
{
    public class ArticleController : Controller
    {
        private readonly ArticleService service;
        private readonly IMapper mapper;
        public ArticleController(ArticleService articleService, IMapper mapper)
        {
            service = articleService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(); ;
        }

        public IActionResult Read(int pageNumber, int pageSize)
        {
            return PartialView("_ArticleView",
                new ArticleRegisterModel()
                {
                    Articles = mapper.Map<List<ArticleDTO>, List<ArticleViewModel>>(service.GetArticleByPageNumberAndPageSize(pageNumber, pageSize))
                });
        }

        public IActionResult View(int id)
        {
            ArticleViewModel article = mapper.Map<ArticleDTO, ArticleViewModel>(service.GetArticle(id));
            article.CanBeUpdated = true;
            return View(article);
        }

        [HttpPost]
        public IActionResult UpdateArticle(ArticleViewModel articleViewModel)
        {
            if (service.ArticleExists(articleViewModel.Id))
            {
                service.UpdateArticle(
                    mapper.Map<ArticleViewModel, ArticleDTO>(articleViewModel));
                return RedirectToAction("View", new { id = articleViewModel.Id });
            }
            throw new System.Exception($"Статья с id {articleViewModel.Id} не существует.");
        }

        public JsonResult CanBeUpdated(int id)
        {
            return Json(true);
        }
    }
}
