using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleRepository.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<UserDTO> Users { get; set; }
    }
}
