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
        private readonly Container _container;

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
            return response.Any();
        }

        public async Task UpdateUserAsync(string id, User user)
        {
            await this._container.UpsertItemAsync<User>(user, new PartitionKey(id));
        }

        public async Task UpdateUserAsync(User user)
        {
            await this._container.UpsertItemAsync<User>(user);
        }

        public async Task AddMiniAsync(Mini mini)
        {
            await this._container.CreateItemAsync<Mini>(mini);
        }

        public async Task DeleteMiniAsync(string id)
        {
            await this._container.DeleteItemAsync<Mini>(id, new PartitionKey(id));
        }

        public async Task<Mini> GetMiniAsync(string id)
        {
            try
            {
                ItemResponse<Mini> response = await this._container.ReadItemAsync<Mini>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task UpdateMiniAsync(Mini mini)
        {
            await this._container.UpsertItemAsync<Mini>(mini);
        }

        public async Task<IEnumerable<Mini>> GetMinisAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Mini>(new QueryDefinition(queryString));
            List<Mini> results = new();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<IEnumerable<Mini>> GetMinisForUser(List<string> miniIds)
        {
            var query = "SELECT * FROM c where c.id IN " + "('" + string.Join("','", miniIds) + "')";
            return await GetMinisAsync(query);
        }
    }
}
