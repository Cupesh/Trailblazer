using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trailblazer.Server.Data.Contexts
{
    public class TrailblazerDataContext : DbContext
    {
        public TrailblazerDataContext(DbContextOptions<TrailblazerDataContext> options) : base(options) => Database.SetCommandTimeout(300);
    }
}
