using ArticleRepository.DTO;
using ArticleRepository.Model;
using ArticleRepository.Service;
using Articles.Models;
using Articles.Models.RegisterModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
            return View(new ArticleRegisterModel()
            {
                Articles = mapper.Map<List<ArticleEntity>, List<ArticleViewModel>>(service.GetAllArticle().ToList())
            }); ;
        }

        public IActionResult View(int id)
        {
            ArticleViewModel article = mapper.Map<ArticleDTO, ArticleViewModel>(service.GetArticle(id));
            article.CanBeUpdated = true;
            return View(article);
        }
    }
}
