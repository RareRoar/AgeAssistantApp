using System.Threading.Tasks;
using SearchApp.Models;

namespace SearchApp.Services
{
    // Firebase authentication adapter
    // адаптер аутентификации Firebase
    public interface IFirebaseAuthAdapter<T> where T : User
    {
        // returns if user exists asynchronously
        // возвращает, существет ли пользователь асинхронно
        Task<bool> IsUserExists(string uname);

        // creates user and returns if succeed asynchronously
        // создаёт пользователя и возвращает, успешно ли асинхронно
        Task<bool> RegisterUser(string uname, string passwd);

        // authenticates user and returns if succeed asynchronously
        // аутентифицирует пользователя и возвращает, успешно ли асинхронно
        Task<bool> LoginUser(string uname, string passwd);
    }
}
