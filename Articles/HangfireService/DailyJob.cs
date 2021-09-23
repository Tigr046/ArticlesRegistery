using ArticleRepository.DTO;
using ArticleRepository.Service;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.HangfireService
{
    public class DailyJob
    {
        private readonly NoticeService noticeService;

        private readonly UserService userService;
        public DailyJob(NoticeService noticeService, IRecurringJobManager recurringJob, UserService userService)
        {
            this.userService = userService;
            this.noticeService = noticeService;
            recurringJob.AddOrUpdate("Проверка дней рождений", () => CheckUsersBirthday(), Cron.Daily, timeZone : TimeZoneInfo.Local);
        }

        public void CheckUsersBirthday()
        {
            List<int> userIdsWhoHaveBirthday = userService.GetUserIdsWithBirthdayByDate(DateTime.Today.Month, DateTime.Today.Day);
            
            foreach(int userId in userIdsWhoHaveBirthday)
            {
                noticeService.AddNewNotice(
                    new NoticeDTO
                    {
                        Message = "Поздравляем вас с днем рождения!!!",
                        IsReaded = false,
                        UserId = userId
                    }
                    );
            }
            
        }
    }
}
