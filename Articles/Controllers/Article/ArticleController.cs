using ArticleRepository.DTO;
using ArticleRepository.Service;
using Articles.HangfireService;
using Articles.Models;
using Articles.Models.RegistryModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Articles.CustomAttribute;
using System.Collections.Generic;

namespace Articles.Controllers.Article
{
    public class ArticleController : Controller
    {
        private readonly ArticleService service;
        private readonly CommentService commentService;
        private readonly IMapper mapper;
        private readonly UserService userService;
        private readonly NoticeSendService noticeSendService;
        public ArticleController(ArticleService articleService, IMapper mapper, CommentService commentService, UserService userService, NoticeSendService noticeSendService)
        {
            this.service = articleService;
            this.mapper = mapper;
            this.commentService = commentService;
            this.noticeSendService = noticeSendService;
            this.userService = userService;
        }
        
        public IActionResult View(int id)
        {
            ArticleViewModel article = mapper.Map<ArticleDTO, ArticleViewModel>(service.GetArticle(id));
            int? userId = userService.GetUserIdByCurrContext(User);
            if (userId.HasValue && article.AuthorId == userId)
                article.CanBeUpdated = true;
            else
                article.CanBeUpdated = false;
            return View(article);
        }

        [CustomAuthorization(Roles: "admin,user")]
        public IActionResult UpdateArticleFromView(int id)
        {
            if (service.ArticleExists(id))
            {
                return PartialView("Update", mapper.Map<ArticleDTO, ArticleViewModel>(service.GetArticle(id)));
            }
            throw new System.Exception($"Статья с id {id} не существует.");
        }

        [HttpPost]
        [CustomAuthorization(Roles: "admin,user")]
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

        public IActionResult ShowComments(int articleId)
        {
            CommentRegistryModel registryModel = new CommentRegistryModel(
                mapper.Map<List<CommentDTO>, List<CommentViewModel>>(commentService.GetCommentsByArticleId(articleId)),
                articleId
                );
            return PartialView("_CommentsView", registryModel);
        }

        [CustomAuthorization(Roles:"admin,user")]
        public IActionResult AddComment(CommentViewModel comment)
        {
            CommentDTO commentToAdd = mapper.Map<CommentViewModel, CommentDTO>(comment);
            commentToAdd.AuthorId =userService.GetUserIdByCurrContext(User).Value;
            commentService.AddComment(commentToAdd);
            noticeSendService.SendNoticeForNewComment(comment.ArticleId);
            return ShowComments(comment.ArticleId);
        }

        [CustomAuthorization(Roles: "admin,user")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [CustomAuthorization(Roles: "admin,user")]
        public IActionResult Create(ArticleViewModel article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }
            service.AddArticle(mapper.Map<ArticleViewModel, ArticleDTO>(article));
            return RedirectToAction("Index","ArticleRegistry");
        }
    }
}
