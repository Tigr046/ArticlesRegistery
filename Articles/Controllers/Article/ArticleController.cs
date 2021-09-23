using ArticleRepository.DTO;
using ArticleRepository.Service;
using Articles.HangfireService;
using Articles.Models;
using Articles.Models.RegistryModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Articles.Controllers.Article
{
    public class ArticleController : Controller
    {
        private readonly ArticleService service;
        private readonly CommentService commentService;
        private readonly IMapper mapper;
        private readonly NoticeSendService noticeSendService;
        public ArticleController(ArticleService articleService, IMapper mapper, CommentService commentService, NoticeSendService noticeSendService)
        {
            this.service = articleService;
            this.mapper = mapper;
            this.commentService = commentService;
            this.noticeSendService = noticeSendService;
        }
        
        public IActionResult View(int id)
        {
            ArticleViewModel article = mapper.Map<ArticleDTO, ArticleViewModel>(service.GetArticle(id));
            article.CanBeUpdated = true;
            return View(article);
        }

        public IActionResult UpdateArticleFromView(int id)
        {
            if (service.ArticleExists(id))
            {
                return PartialView("Update", mapper.Map<ArticleDTO, ArticleViewModel>(service.GetArticle(id)));
            }
            throw new System.Exception($"Статья с id {id} не существует.");
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

        public IActionResult ShowComments(int articleId)
        {
            CommentRegistryModel registryModel = new CommentRegistryModel(
                mapper.Map<List<CommentDTO>, List<CommentViewModel>>(commentService.GetCommentsByArticleId(articleId)),
                articleId
                );
            return PartialView("_CommentsView", registryModel);
        }

        public IActionResult AddComment(CommentViewModel comment)
        {
            CommentDTO commentToAdd = mapper.Map<CommentViewModel, CommentDTO>(comment);
            commentToAdd.AuthorId = GetUserIdByCurrContext();
            commentService.AddComment(commentToAdd);
            noticeSendService.SendNoticeForNewComment(comment.ArticleId);
            return ShowComments(comment.ArticleId);
        }

        private int GetUserIdByCurrContext()
        {
            int userId = 0;
            if (Int32.TryParse(User.FindFirst((x) => x.Type == "Id")?.Value, out userId))
            {
                return userId;
            }
            throw new Exception("Значение id получение из куки неполучилось сконвертировать в int");
        }
    }
}
