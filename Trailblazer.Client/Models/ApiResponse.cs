using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trailblazer.Models
{
    // Response with no Payload data
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public bool IsSessionTimedOut { get; set; }
        public string ErrorMessage { get; set; }
    }

    // Response with Payload data
    public class ApiResponse<T> : ApiResponse
    {
        public T ApiData { get; set; }
    }

    public class PagedDataList<T>
    {
        public int RecordCount { get; set; }
        public List<T> DataList { get; set; }
        public object AdditionalData { get; set; }
    }


    public class ModelStateValidationError
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public Errors Errors { get; set; }
    }

    public class Errors
    {
        public string[] Email { get; set; }
    }


}
