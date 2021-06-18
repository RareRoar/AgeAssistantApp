using SearchApp.Models;
using SearchApp.Services;
using SearchApp.Views;
using Firebase.Database;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // mocking service registation
            // регистрация сервиса для наполнения базы данных
            DependencyService.Register<MockDataStore>();

            // database mocking itself
            // собственно наполнение базы данных фиктивными объектами
            DependencyService.Get<IFirebaseDataAdapter<Item>>().MockDatabase();

            // authentication service registation
            // регистрация сервиса авторизации
            DependencyService.Register<UserService>();

            // shell boot
            //запуск оболочки
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
