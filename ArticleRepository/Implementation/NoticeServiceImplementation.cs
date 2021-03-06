using ArticleRepository.DTO;
using ArticleRepository.Model;
using ArticleRepository.Repository;
using ArticleRepository.Service;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ArticleRepository.Implementation
{
    public class NoticeServiceImplementation : NoticeService
    {
        private readonly ArticleDbContext context;
        private readonly IMapper mapper;

        public NoticeServiceImplementation(ArticleDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int GetUnreadedNoticeCountByUserId(int userId)
        {
            return context.User.Include(x => x.Notices).FirstOrDefault(x => x.Id == userId)?.Notices?.Where(x => !x.IsReaded)?.Count() ?? 0;
        }

        public List<NoticeDTO> GetUnreadedNoticeByUserId(int userId)
        {
            return mapper.Map<List<NoticeEntity>, List<NoticeDTO>>(context.User.Include(x => x.Notices).FirstOrDefault(x => x.Id == userId)?.Notices?.Where(x => !x.IsReaded)?.ToList() ?? new List<NoticeEntity>());
        }

        public List<NoticeDTO> GetAllNoticesByUser(int userId) => mapper.Map<List<NoticeEntity>, List<NoticeDTO>>(context.Notice.Where(x => x.UserId == userId).ToList());

        public void MarkNoticeAsRead(int noticeId)
        {
            NoticeEntity noticeToChange = context.Notice.FirstOrDefault(x => x.Id == noticeId);
            noticeToChange.IsReaded = true;
            context.SaveChanges();
        }

        public NoticeDTO AddNewNotice(NoticeDTO notice)
        {
            NoticeDTO addedNotice = mapper.Map<NoticeEntity, NoticeDTO>(context.Notice.Add(mapper.Map<NoticeDTO, NoticeEntity>(notice)).Entity);
            context.SaveChanges();
            return addedNotice;
        }

        public void DeleteNotice(int id)
        {
            context.Notice.Remove(context.Notice.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }
    }
}
