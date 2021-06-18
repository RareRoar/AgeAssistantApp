using SearchApp.Models;
using System.Threading.Tasks;

namespace SearchApp.ViewModels
{
    class UserViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        // saves model into Firebase RT DB asynchonously
        // сохраняет модель в Firebase RT DB асинхронно
        public async Task<bool> SaveModelAsync()
        {
            return await FirebaseAdapter.RegisterUser(Username, Password);
        }

        // authenticates model in Firebase RT DB asynchonously
        // аутентифицирует модель в Firebase RT DB асинхронно
        public async Task<bool> AuthenticateModelAsync()
        {
            return await FirebaseAdapter.LoginUser(Username, Password);
        }
    }
}
