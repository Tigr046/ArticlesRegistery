using ArticleRepository.DTO;
using ArticleRepository.Service;
using Articles.Models;
using Articles.Models.RegisterModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Controllers.Article
{
    public class ArticleRegisterController : Controller
    {
        private readonly ArticleService service;
        private readonly IMapper mapper;
        public ArticleRegisterController(ArticleService articleService, IMapper mapper)
        {
            service = articleService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Read(int pageNumber, int pageSize)
        {
            return PartialView("_ArticleView",
                new ArticleRegisterModel()
                {
                    Articles = mapper.Map<List<ArticleDTO>, List<ArticleViewModel>>(service.GetArticleByPageNumberAndPageSize(pageNumber, pageSize))
                });
        }
    }
}
