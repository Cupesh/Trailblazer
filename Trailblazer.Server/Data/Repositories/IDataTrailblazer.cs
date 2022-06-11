using Trailblazer.Server.Models;

namespace Trailblazer.Server.Data.Repositories
{
    public interface IDataTrailblazer
    {
        Task<List<User>> Test();
    }
}
