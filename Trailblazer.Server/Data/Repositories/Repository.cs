using Microsoft.EntityFrameworkCore;
using System.Data;
using Dapper;
using System.Data.SqlClient;


namespace Trailblazer.Server.Data.Repositories
{
    public class Repository<TDbContext> : IRepository<TDbContext> where TDbContext : DbContext
    {
        protected readonly TDbContext _ctx;

        public TDbContext Context => _ctx;

        public SqlConnection GetConnection() => new(_ctx.Database.GetDbConnection().ConnectionString);

        public Repository(TDbContext context) => _ctx = context;




        public async Task RunDapperAsync(string sproc, object pars = null)
        {
            using SqlConnection dapperConn = GetConnection();
            await dapperConn.ExecuteScalarAsync(sproc, pars, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetDapperScalarAsync<T>(string sproc, object pars = null, CommandType type = CommandType.StoredProcedure)
        {
            using SqlConnection dapperConn = GetConnection();
            var data = await dapperConn.ExecuteScalarAsync<T>(sproc, pars, commandType: type);
            return data;
        }

        public async Task<List<T>> GetDapperListAsync<T>(string sproc, object pars = null, CommandType type = CommandType.StoredProcedure)
        {
            using SqlConnection dapperConn = GetConnection();
            var data = await dapperConn.QueryAsync<T>(sproc, pars, commandType: type);
            return data.ToList();
        }

        public async Task<IEnumerable<dynamic>> GetDapperDynamicList(string sproc, object pars = null, CommandType type = CommandType.StoredProcedure)
        {
            using SqlConnection dapperConn = GetConnection();
            var data = await dapperConn.QueryAsync(sproc, pars, commandType: type);
            return data;
        }

        public async Task ExecuteDapperAsync(string sql, object pars = null)
        {
            using SqlConnection dapperConn = GetConnection();
            await dapperConn.ExecuteAsync(sql, pars);
        }
    }
}