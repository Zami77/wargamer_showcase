using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;

namespace wargamer_showcase.Data
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

        public async Task AddUserAsync(User user)
        {
            await this._container.CreateItemAsync<User>(user);
        }

        public async Task AddPaintAsync(Paint paint)
        {
            await this._container.CreateItemAsync<Paint>(paint);
        }

        public async Task DeleteUserAsync(string id)
        {
            await this._container.DeleteItemAsync<User>(id, new PartitionKey(id));
        }
        public async Task DeletePaintAsync(string id)
        {
            await this._container.DeleteItemAsync<Paint>(id, new PartitionKey(id));
        }

        public async Task<User> GetUserAsync(string id)
        {
            try
            {
                ItemResponse<User> response = await this._container.ReadItemAsync<User>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }


        public async Task<Paint> GetPaintAsync(string id)
        {
            try
            {
                ItemResponse<Paint> response = await this._container.ReadItemAsync<Paint>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<IEnumerable<User>> GetUsersAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<User>(new QueryDefinition(queryString));
            List<User> results = new();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
        public async Task<IEnumerable<Paint>> GetPaintsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Paint>(new QueryDefinition(queryString));
            List<Paint> results = new();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<IEnumerable<Paint>> GetAllPaintsAsync()
        {
            var query = "SELECT * FROM c WHERE c.category = 'paints'";
            return await GetPaintsAsync(query);
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            var query = $"SELECT * FROM c WHERE c.username = '{username}'";
            var response = await GetUsersAsync(query);
            return response.FirstOrDefault();
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            var query = $"SELECT * FROM c WHERE c.username ='{username}'";
            var response = await GetUsersAsync(query);
            return response.Count() > 0;
        }

        public async Task UpdateUserAsync(string id, User user)
        {
            await this._container.UpsertItemAsync<User>(user, new PartitionKey(id));
        }

        public async Task UpdateUserAsync(User user)
        {
            await this._container.UpsertItemAsync<User>(user);
        }
    }
}
