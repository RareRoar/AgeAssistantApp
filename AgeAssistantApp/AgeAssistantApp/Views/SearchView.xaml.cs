using SearchApp.Models;
using SearchApp.Services;
using Firebase.Database;
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
    public partial class SearchView : ContentPage
    {
        public SearchView()
        {
            InitializeComponent();
        }

        public List<Item> Items { get; set; }

        // 'seacrh' button click handler: performs search
        // обработчик нажатия на кнопку 'search': производит поиск
        private async void SearchButtonHandlerAsync(object sender, EventArgs e)
        {
            Items = (await DependencyService.Get<IFirebaseDataAdapter<Item>>().GetItemsByTemplate(searchEntry.Text)).ToList();
            BindingContext = this;
        }

        // list view item selection handler: created pop-up window with item information
        // обработчик нажатия на элемент представления списка: создаёт вспылающее окно с информацией о товаре
        private async void scrollLayoutItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            
            Item selectedItem = e.SelectedItem as Item;
            if (selectedItem != null)
                await DisplayAlert(selectedItem.Text, selectedItem.Description, "OK");
        }
    }
}