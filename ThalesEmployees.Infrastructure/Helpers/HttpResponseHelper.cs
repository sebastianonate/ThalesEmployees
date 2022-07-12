using ThalesEmployees.Core.Application.Exceptions;

namespace ThalesEmployees.Infrastructure.Helpers
{
    public static class HttpResponseHelper
    {
        public static async Task<string> GetResponseAsStringAsync(HttpResponseMessage response) 
        {
            var stringfyResponse = await response.Content.ReadAsStringAsync();
            if (stringfyResponse.StartsWith("<!DOCTYPE html>"))
                throw new TooManyRequestsException("Too Many Requests to the base API");
            return stringfyResponse;
        }
    }
}
