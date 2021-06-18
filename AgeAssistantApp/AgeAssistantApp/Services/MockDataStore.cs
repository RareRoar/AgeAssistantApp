using SearchApp.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchApp.Services
{
    public class MockDataStore : IDataStore<Item>, IFirebaseDataAdapter<Item>
    {
        private const int listSize = 20;
        readonly List<Item> items;
        private readonly FirebaseClient client;

        public MockDataStore()
        {

            // https://ageassistantapp-default-rtdb.firebaseio.com/
            client = new FirebaseClient("https://searchapp-967ca-default-rtdb.firebaseio.com/");

            items = new List<Item>();
            for (int i = 0; i < listSize; i++) 
            {
                string text = string.Format("{0}th item", i + 1);
                if (i == 0)
                {
                    text = "1st item";
                }
                else if (i == 1)
                {
                    text = "2nd item";
                }
                else if (i == 2)
                {
                    text = "3rd item";
                }
                items.Add(new Item
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = text,
                    Description = "This is an item description."
                });
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task MockDatabase()
        {
            if ((await client.Child("Items").OnceAsync<Item>()).FirstOrDefault() == null)
            {
                foreach (var item in items)
                {
                    await client.Child("Items").PostAsync(item);
                }
            }
        }

        public async Task<IEnumerable<Item>> GetItemsByTemplate(string template)
        {
            return (from i in await client.Child("Items").OnceAsync<Item>() where i.Object.Text.Contains(template)
                    select new Item
            {
                Id = i.Object.Id,
                Text = i.Object.Text,
                Description = i.Object.Description
            }).ToList();
        }
    }
}