using ArticleRepository.DTO;
using System;
using System.Collections.Generic;

namespace ArticleRepository.Service
{
    public interface UserService
    {
        UserDTO GetUserByEmailAndPassword(string email, string password);

        List<int> GetUserIdsWithBirthdayByDate(int month, int day);

        bool UserWithEmailCreated(string email);

        UserDTO AddNewUser(UserDTO user);
    }
}
