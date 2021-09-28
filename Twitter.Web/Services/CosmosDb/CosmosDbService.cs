using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Web.Interfaces;
using Twitter.Web.Models;

namespace Twitter.Web.Services.CosmosDb
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(ItemViewModel item)
        {
            await this._container.CreateItemAsync<ItemViewModel>(item, new PartitionKey(item.Id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<ItemViewModel>(id, new PartitionKey(id));
        }

        public async Task<ItemViewModel> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<ItemViewModel> response = await this._container.ReadItemAsync<ItemViewModel>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<IEnumerable<ItemViewModel>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<ItemViewModel>(new QueryDefinition(queryString));
            List<ItemViewModel> results = new List<ItemViewModel>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, ItemViewModel item)
        {
            await this._container.UpsertItemAsync<ItemViewModel>(item, new PartitionKey(id));
        }
    }
}
