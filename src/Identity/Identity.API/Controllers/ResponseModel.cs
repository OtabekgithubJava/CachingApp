using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Identity.API.Controllers
{
    internal class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}