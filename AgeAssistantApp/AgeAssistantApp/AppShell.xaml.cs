using SearchApp.Views;
using Xamarin.Forms;

namespace SearchApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // routes registering
            // регистрация путей
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(SignUpView), typeof(SignUpView));
            Routing.RegisterRoute(nameof(SearchView), typeof(SearchView));
        }

    }
}
