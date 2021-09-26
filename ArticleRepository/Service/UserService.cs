using ArticleRepository.DTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ArticleRepository.Service
{
    public interface UserService
    {
        UserDTO GetUserByEmailAndPassword(string email, string password);

        List<int> GetUserIdsWithBirthdayByDate(int month, int day);

        bool UserWithEmailCreated(string email);

        UserDTO AddNewUser(UserDTO user);

        List<UserDTO> GetAllUsersByPageNumberAndPageSize(int pageSize, int pageNumber);

        UserDTO GetUser(int id);

        UserDTO UpdateUser(UserDTO user); 

        RoleDTO GetUserRoleByUserId(int userId);

        int? GetUserIdByCurrContext(ClaimsPrincipal user);
    }
}
