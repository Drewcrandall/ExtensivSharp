using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ExtensivSharp.Models.Helper
{
    public static class HttpStatusCodeHelper
    {
        public static void SetResponseMessage<T>(HttpResponseMessage response, ExtensivApiResult<T> result, string responseContent)
        {
            switch (response.StatusCode)
            {
                // 100's: Informational
                case HttpStatusCode.Continue:
                    result.Message = "Continue with the request.";
                    break;
                case HttpStatusCode.SwitchingProtocols:
                    result.Message = "Server is switching protocols as requested.";
                    break;

                // 200's: Success - not handled here. should do it yourself in the calling code

                // 300's: Redirection
                case HttpStatusCode.MultipleChoices:
                    result.Message = "Multiple options available for the resource.";
                    break;
                case HttpStatusCode.MovedPermanently:
                    result.Message = "Resource has been permanently moved.";
                    break;
                case HttpStatusCode.Found:
                    result.Message = "Resource temporarily moved.";
                    break;
                case HttpStatusCode.SeeOther:
                    result.Message = "Resource can be found at another URI.";
                    break;
                case HttpStatusCode.NotModified:
                    result.Message = "Resource has not been modified.";
                    break;
                case HttpStatusCode.UseProxy:
                    result.Message = "Use the specified proxy to access this resource.";
                    break;
                case HttpStatusCode.TemporaryRedirect:
                    result.Message = "Resource temporarily moved to another URI.";
                    break;

                // 400's: Client errors
                case HttpStatusCode.BadRequest:
                    result.Message = "Invalid request. Please check your input parameters.";
                    break;
                case HttpStatusCode.Unauthorized:
                    result.Message = "Authentication failed. Please check your credentials.";
                    break;
                case HttpStatusCode.PaymentRequired:
                    result.Message = "Payment is required to access this resource.";
                    break;
                case HttpStatusCode.Forbidden:
                    result.Message = "You don't have permission to access this resource.";
                    break;
                case HttpStatusCode.NotFound:
                    result.Message = "The requested resource was not found.";
                    break;
                case HttpStatusCode.MethodNotAllowed:
                    result.Message = "The HTTP method used is not allowed for this resource.";
                    break;
                case HttpStatusCode.NotAcceptable:
                    result.Message = "The requested resource cannot generate content according to the Accept headers.";
                    break;
                case HttpStatusCode.ProxyAuthenticationRequired:
                    result.Message = "Proxy authentication is required.";
                    break;
                case HttpStatusCode.RequestTimeout:
                    result.Message = "Request timed out. Please try again.";
                    break;
                case HttpStatusCode.Conflict:
                    result.Message = "Request couldn't be completed due to a conflict.";
                    break;
                case HttpStatusCode.Gone:
                    result.Message = "The requested resource is no longer available.";
                    break;
                case HttpStatusCode.LengthRequired:
                    result.Message = "Content-Length header is required.";
                    break;
                case HttpStatusCode.PreconditionFailed:
                    result.Message = "Precondition given in request headers evaluated to false.";
                    break;
                case HttpStatusCode.RequestEntityTooLarge:
                    result.Message = "Request entity is too large.";
                    break;
                case HttpStatusCode.RequestUriTooLong:
                    result.Message = "Request URI is too long.";
                    break;
                case HttpStatusCode.UnsupportedMediaType:
                    result.Message = "Unsupported media type in the request.";
                    break;
                case HttpStatusCode.RequestedRangeNotSatisfiable:
                    result.Message = "Requested range cannot be satisfied.";
                    break;
                case HttpStatusCode.ExpectationFailed:
                    result.Message = "Server cannot meet the expectation given in the Expect header.";
                    break;

                // 500's: Server errors
                case HttpStatusCode.InternalServerError:
                    result.Message = "Server encountered an internal error.";
                    break;
                case HttpStatusCode.NotImplemented:
                    result.Message = "The server does not support the functionality required.";
                    break;
                case HttpStatusCode.BadGateway:
                    result.Message = "Invalid response received from the upstream server.";
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    result.Message = "Service is temporarily unavailable. Please try again later.";
                    break;
                case HttpStatusCode.GatewayTimeout:
                    result.Message = "Upstream server did not respond in time.";
                    break;
                case HttpStatusCode.HttpVersionNotSupported:
                    result.Message = "HTTP version not supported.";
                    break;

                // Default
                default:
                    result.Message = $"Unknown API error: {response.StatusCode} - {responseContent}";
                    break;
            }
        }
    }
}
