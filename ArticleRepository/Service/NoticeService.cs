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

        void MarkNoticeAsRead(int noticeId);
    }
}
