using System.Collections.Generic;
using System.Threading.Tasks;
using Twitter.Web.Models;

namespace Twitter.Web.Interfaces
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<ItemViewModel>> GetItemsAsync(string query);
        Task<ItemViewModel> GetItemAsync(string id);
        Task AddItemAsync(ItemViewModel item);
        Task UpdateItemAsync(string id, ItemViewModel item);
        Task DeleteItemAsync(string id);
    }
}