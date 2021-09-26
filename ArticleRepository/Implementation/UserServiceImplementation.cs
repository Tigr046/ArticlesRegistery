using ArticleRepository.DTO;
using ArticleRepository.Model;
using ArticleRepository.Repository;
using ArticleRepository.Service;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

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

        public List<UserDTO> GetAllUsersByPageNumberAndPageSize(int pageSize, int pageNumber)
        {
            int skipItemCount = pageSize * pageNumber - 1 < 0 ? 0 : pageSize * pageNumber - 1;
            return mapper.Map<List<UserEntity>, List<UserDTO>>(
                context.User.AsQueryable().Skip(skipItemCount).Take(pageSize).ToList());

        }

        public UserDTO GetUserByEmailAndPassword(string email, string password)
        {
            return mapper.Map<UserEntity, UserDTO>(context.User.Include(x => x.Role).FirstOrDefault(u => u.Email == email && u.Password == password));
        }

        public bool UserWithEmailCreated(string email)
        {
            return context.User.FirstOrDefault(u => u.Email == email) != null ? true : false;
        }

        public UserDTO AddNewUser(UserDTO user)
        {
            UserEntity userToAdd = mapper.Map<UserDTO, UserEntity>(user);
            userToAdd.Role = context.Role.FirstOrDefault(x => x.Name == "user");
            UserEntity addedUser = context.Add(userToAdd).Entity;
            context.SaveChanges();
            return mapper.Map<UserEntity,UserDTO>(addedUser);
        }

        public List<int> GetUserIdsWithBirthdayByDate(int month, int day)
        {
            return context.User.Where(x => x.Birthday.Month == month && x.Birthday.Day == day).Select(x => x.Id).ToList();
        }

        public UserDTO GetUser(int id)
        {
            return mapper.Map<UserEntity, UserDTO>(GetUserEntity(id));
        }

        public RoleDTO GetUserRoleByUserId(int userId)
        {
            return mapper.Map<RoleEntity, RoleDTO>(GetUserEntity(userId).Role);
        }

        public UserDTO UpdateUser(UserDTO user)
        {
            UserEntity userToUpdate = mapper.Map(user, GetUserEntity(user.Id));
            context.SaveChanges();
            return mapper.Map<UserEntity, UserDTO>(userToUpdate);
        }

        public int? GetUserIdByCurrContext(ClaimsPrincipal user)
        {
            int userId = 0;
            if (Int32.TryParse(user.FindFirst((x) => x.Type == "Id")?.Value, out userId))
            {
                return userId;
            }
            return null;
        }

        private UserEntity GetUserEntity(int id) => context.User.Include(x => x.Role).FirstOrDefault(x => x.Id == id) ?? throw new Exception($"Не найден пользователь с идентификатором {id}");
    }
}
