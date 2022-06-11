using System.Data;
using Trailblazer.Server.Data.Contexts;
using Trailblazer.Server.Models;

namespace Trailblazer.Server.Data.Repositories
{
    public class DataTrailblazer : IDataTrailblazer
    {
        private readonly IRepository<TrailblazerDataContext> _repository;

        public DataTrailblazer(TrailblazerDataContext context) => _repository = new Repository<TrailblazerDataContext>(context);

        public async Task<List<User>> Test()
        {
            var sql = "SELECT UserName FROM tblUsers";
            var data = await _repository.GetDapperListAsync<User>(sql, null, CommandType.Text);

            return data;
        }
    }
}
