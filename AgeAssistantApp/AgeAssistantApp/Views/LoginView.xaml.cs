using SearchApp.Services;
using SearchApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        private readonly UserViewModel userVM;

        public LoginView()
        {
            InitializeComponent();
            userVM = new UserViewModel();
            BindingContext = userVM;
        }

        // 'LOGIN' button click handler: goes to seacrh page or alerts about failure
        // обработчик нажатия кнопки 'LOGIN': переходит на страницу поиска или оповещает об ошибке
        private async void ButtonLoginHandler(object sender, EventArgs e)
        {
            if (await userVM.AuthenticateModelAsync()) {
                await Shell.Current.GoToAsync($"SearchView");
            }
            else
            {
                _ = DisplayAlert("Denied!", "The data is not relevant.", "OK");
            }
        }

        // 'REGISTER' button click handler: goes to sign up page
        // обработчик нажатия кнопки 'REGISTER': переходит на страницу создания учётной записи
        private async void ButtonRegisterHandler(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"SignUpView");
        }
    }
}