using ArticleRepository.DTO;
using ArticleRepository.Service;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.HangfireService
{
    public class NoticeSendService {
        private NoticeService noticeService;
        private ArticleService articleService;

        public NoticeSendService(NoticeService noticeService, ArticleService articleService)
        {
            this.articleService = articleService;
            this.noticeService = noticeService;
        }
        public void SendNoticeForNewComment(int articleId)
        {
            BackgroundJob.Enqueue(() => CreateNewNotice(articleId));
        }

        public void CreateNewNotice(int articleId)
        {
            ArticleDTO article = articleService.GetArticle(articleId);
            string noticeMessage = $"У вас новый комментарий к статье \"{article.Title}\".";
            if(!noticeService.GetUnreadedNoticeByUserId(article.AuthorId).Any(x => x.Message == noticeMessage))
            {
                noticeService.AddNewNotice(
                    new NoticeDTO
                    {
                        Message = noticeMessage,
                        IsReaded = false,
                        UserId = article.AuthorId
                    }
                    );
            }

        }
    }
}
