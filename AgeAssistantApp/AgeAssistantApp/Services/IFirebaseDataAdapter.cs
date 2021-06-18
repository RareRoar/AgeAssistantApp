using SearchApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchApp.Services
{
    // Firebase data adapter
    // адаптер для работы с данными в Firebase
    public interface IFirebaseDataAdapter<T> where T : Item
    {
        // fill database with mock-objects
        // наполнить базу данных фиктивными объектами
        Task MockDatabase();

        // returns collection of elements selected by string template
        // возвращает коллекцию элементов, выбранных по строковому шаблону
        Task<IEnumerable<T>> GetItemsByTemplate(string template);
    }
}
