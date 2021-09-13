using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wargamer_showcase.Data
{
    public interface ICosmosDbService
    {
        /* Users */
        Task<IEnumerable<User>> GetUsersAsync(string query);
        Task<User> GetUserAsync(string id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(string id, User user);
        Task DeleteUserAsync(string id);
        Task<bool> UserExistsAsync(string username);

        /* Paints */
        Task AddPaintAsync(Paint paint);
        Task DeletePaintAsync(string id);
        Task<Paint> GetPaintAsync(string id);
        Task<IEnumerable<Paint>> GetPaintsAsync(string query);
        Task<IEnumerable<Paint>> GetAllPaintsAsync();

        /* Minis */
    }
}
