using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ExtensivSharp.Models.Helper
{
    public class ExtensivApiResult<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public string? Etag { get; set; }

        public bool IsSuccess() => Success;
        public bool IsUnauthorized() => StatusCode == HttpStatusCode.Unauthorized;
        public bool IsNotFound() => StatusCode == HttpStatusCode.NotFound;
    }
}
