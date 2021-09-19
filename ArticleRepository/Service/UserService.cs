using ArticleRepository.DTO;

namespace ArticleRepository.Service
{
    public interface UserService
    {
        UserDTO GetUserByEmailAndPassword(string email, string password);

        bool UserWithEmailCreated(string email);

        int AddNewUser(UserDTO user);
    }
}
