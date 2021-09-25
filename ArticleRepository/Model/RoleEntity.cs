using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleRepository.Model
{
    public class RoleEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<UserEntity> Users { get; set; }
    }
}
