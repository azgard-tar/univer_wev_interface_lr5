using System.Collections.Generic;

namespace LR5
{
    internal class ApiResponseModel<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public List<T> Data { get; set; } = new List<T>();
    }
}
