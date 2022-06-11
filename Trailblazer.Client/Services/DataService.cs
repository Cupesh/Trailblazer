using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trailblazer.Models;

namespace Trailblazer.Services
{
    internal class DataService : IDataService
    {
        private readonly ServerAPIClient _client;

        public DataService(ServerAPIClient serverClient)
        {
            _client = serverClient;
        }

        public async Task<ApiResponse<List<User>>> Test()
        {
            string url = $"Test/Test";
            return await _client.GetDataAsync<List<User>>(url);
        }
    }
}
