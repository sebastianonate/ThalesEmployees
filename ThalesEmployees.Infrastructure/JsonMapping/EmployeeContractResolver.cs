using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesEmployees.Infrastructure.JsonMapping
{
    public class EmployeeContractResolver : DefaultContractResolver
    {
        private readonly Dictionary<string, string> ExceptionalPropertiesMapping = new Dictionary<string, string> {
            { "ProfileImage", "profile_image"},
            { "Name", "employee_name"},
            { "Salary", "employee_salary"},
            { "Age", "employee_age"}
        };

        protected override string ResolvePropertyName(string propertyName)
        {
            ExceptionalPropertiesMapping.TryGetValue(propertyName, out string? resolvedName);
            return resolvedName ?? base.ResolvePropertyName(propertyName);
        }
    }
}
