using System;
using System.Linq;
using System.Threading.Tasks;
using SearchApp.Models;
using Firebase.Database;
using Firebase.Database.Query;

namespace SearchApp.Services
{
    // authentication service
    // сервис аутентификации
    public class UserService : IFirebaseAuthAdapter<User>
    {
        FirebaseClient client;

        public UserService()
        {
            /*
             * https://ageassistantapp-default-rtdb.firebaseio.com/
             */
            client = new FirebaseClient("https://searchapp-967ca-default-rtdb.firebaseio.com/");
        }

        // inteface implementation
        // реализация интерфейса
        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("Users").OnceAsync<User>())
                .Where(u => u.Object.Username == uname)
                .FirstOrDefault();
            return user != null;
        }

        // inteface implementation
        // реализация интерфейса
        public async Task <bool> RegisterUser(string uname, string passwd)
        {
            if (!await IsUserExists(uname))
            {
                await client.Child("Users").PostAsync(new User(uname, passwd));
                return true;
            }
            else
            {
                return false;
            }
        }

        // inteface implementation
        // реализация интерфейса
        public async Task <bool> LoginUser(string uname, string passwd)
        {
            var user = (await client.Child("Users").OnceAsync<User>())
                .Where(u => u.Object.Username == uname)
                .Where(u => u.Object.Password == passwd)
                .FirstOrDefault();
            return user != null;
        }
    }
}
