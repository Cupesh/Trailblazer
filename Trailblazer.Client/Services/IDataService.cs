using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trailblazer.Models;

namespace Trailblazer.Services
{
    public interface IDataService
    {
        Task<ApiResponse<List<User>>> Test();
    }
}
