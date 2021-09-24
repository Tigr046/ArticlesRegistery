using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleRepository.Model
{
    public class NoticeEntity
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public bool IsReaded { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }

    }
}
