using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesEmployees.Infrastructure.Helpers
{
    public static class HttpResponseHelper
    {
        public static async Task<string> GetResponseAsStringAsync(HttpResponseMessage response) 
        {
            var stringfyResponse = await response.Content.ReadAsStringAsync();
            if (stringfyResponse.StartsWith("<!DOCTYPE html>"))
                throw new Exception("Too Many Requests");
            return stringfyResponse;
        }
    }
}
