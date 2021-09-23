using ArticleRepository.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleRepository.Service
{
    public interface NoticeService
    {
        int GetUnreadedNoticeCountByUserId(int userId);
        List<NoticeDTO> GetAllNoticesByUser(int userId);
        NoticeDTO AddNewNotice(NoticeDTO notice);


        void MarkNoticeAsRead(int noticeId);

        List<NoticeDTO> GetUnreadedNoticeByUserId(int userId);
    }
}
