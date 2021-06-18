using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpView : ContentPage
    {
        private readonly UserViewModel userVM;
        public SignUpView()
        {
            InitializeComponent();
            userVM = new UserViewModel();
            BindingContext = userVM;
        }

        private async void SignUpButtonHandler(object sender, EventArgs e)
        {
            string confirmPasswordValue = confirmEntry.Text;
            if (userVM.Username != "" &&
                userVM.Password != "" &&
                userVM.Password == confirmPasswordValue)
            {
                await userVM.SaveModelAsync();
                await Shell.Current.GoToAsync($"//LoginPage");
            }
            else
            {
                await DisplayAlert("Oops...", "The data is irrelevant!", "OK");
            }
        }
    }
}