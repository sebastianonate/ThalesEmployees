using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesEmployees.Infrastructure.JsonMapping
{
    public static class JsonSerializerSettingsBuilder
    {
        public static JsonSerializerSettings Build(DefaultContractResolver contractResolver) 
        {
            return new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            };
        }
    }
}
