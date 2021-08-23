using ArticleRepository.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Controllers.Article
{
    public class ArticleController : Controller
    {
        private readonly ArticleService service;
        public ArticleController(ArticleService articleService)
        {
            service = articleService;
        }
        public IActionResult Index()
        {
            var a = service.GetArticle(2);
            return View();
        }
    }
}
