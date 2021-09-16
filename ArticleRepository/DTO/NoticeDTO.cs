namespace ArticleRepository.DTO
{
    public class NoticeDTO
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public bool IsReaded { get; set; }

        public int UserId { get; set; }
        public UserDTO User { get; set; }

    }
}
