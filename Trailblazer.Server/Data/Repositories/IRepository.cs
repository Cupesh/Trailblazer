using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Trailblazer.Server.Data.Repositories
{
    public interface IRepository<TDbContext> where TDbContext : DbContext
    {
        TDbContext Context { get; }

        SqlConnection GetConnection();
        Task<List<T>> GetDapperListAsync<T>(string sproc, object pars = null, CommandType type = CommandType.StoredProcedure);
        Task<T> GetDapperScalarAsync<T>(string sproc, object pars = null, CommandType type = CommandType.StoredProcedure);
        Task RunDapperAsync(string sproc, object pars = null);
        Task ExecuteDapperAsync(string sql, object pars = null);
        Task<IEnumerable<dynamic>> GetDapperDynamicList(string sproc, object pars = null, CommandType type = CommandType.StoredProcedure);
    }
}
