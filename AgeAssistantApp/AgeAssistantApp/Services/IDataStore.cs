using System.Collections.Generic;
using System.Threading.Tasks;
using SearchApp.Models;

namespace SearchApp.Services
{
    // intefrace for item collection
    // интерфейс для коллеции товаров
    public interface IDataStore<T> where T : Item
    {
        // adds item into collection and returns if succeed
        // добавляет товар в коллецию и возвращает, успешно ли
        Task<bool> AddItemAsync(T item);

        // updates item in the collection and returns if succeed
        // обновляет товар в коллеции и возвращает, успешно ли
        
        Task<bool> UpdateItemAsync(T item);
        
        // deletes item in the collection and returns if succeed
        // удаляет товар из коллецию и возвращает, успешно ли
        Task<bool> DeleteItemAsync(string id);
        
        // returns element from collection by id
        // возвращает элемент из коллеции по идентификатору
        Task<T> GetItemAsync(string id);

        // return collection object
        // возвращает объект коллекции
        Task<IEnumerable<T>> GetItemsAsync();
    }
}
