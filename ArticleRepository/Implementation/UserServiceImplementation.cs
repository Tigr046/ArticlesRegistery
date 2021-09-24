using ArticleRepository.DTO;
using ArticleRepository.Model;
using ArticleRepository.Repository;
using ArticleRepository.Service;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArticleRepository.Implementation
{
    public class UserServiceImplementation : UserService
    {
        private readonly ArticleDbContext context;
        private readonly IMapper mapper;

        public UserServiceImplementation(ArticleDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public UserDTO GetUserByEmailAndPassword(string email, string password)
        {
            return mapper.Map<UserEntity, UserDTO>(context.User.FirstOrDefault(u => u.Email == email && u.Password == password));
        }

        public bool UserWithEmailCreated(string email)
        {
            return context.User.FirstOrDefault(u => u.Email == email) != null ? true : false;
        }

        public int AddNewUser(UserDTO user)
        {
            UserEntity addedUser = context.Add(mapper.Map<UserDTO, UserEntity>(user)).Entity;
            context.SaveChanges();
            return addedUser.Id;
        }

        public List<int> GetUserIdsWithBirthdayByDate(int month, int day)
        {
            return context.User.Where(x => x.Birthday.Month == month && x.Birthday.Day == day).Select(x => x.Id).ToList();
        }
    }
}
