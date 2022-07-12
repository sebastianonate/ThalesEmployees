using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ThalesEmployees.Core.Domain;
using ThalesEmployees.Core.Domain.Contracts;
using ThalesEmployees.Infrastructure.Helpers;
using ThalesEmployees.Infrastructure.JsonMapping;

namespace ThalesEmployees.Infrastructure.DataAccess
{
    public class ReadRepositoryEmployee : IReadRepositoryEmployee
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiGetAllEmployees;
        private readonly string _apiGetEmployee;
        public ReadRepositoryEmployee(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiGetAllEmployees = configuration["Apis:Employees:GetAll"];
            _apiGetEmployee = configuration["Apis:Employees:Get"];

        }
        public async Task<List<Employee>> GetAllAsync()
        {
            var stringfyContent = await HttpResponseHelper.GetResponseAsStringAsync(await _httpClient.GetAsync(_apiGetAllEmployees));
            
            var employeeApiResponse = JsonConvert
                .DeserializeObject<EmployeesGetAllApiResponse>(stringfyContent, 
                JsonSerializerSettingsBuilder.Build(new EmployeeContractResolver()));

            return employeeApiResponse?.Data ?? new List<Employee>();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            var stringfyContent = await HttpResponseHelper.GetResponseAsStringAsync(await _httpClient.GetAsync($"{_apiGetEmployee}/{id}"));

            var employeeApiResponse = JsonConvert
                .DeserializeObject<EmployeeGetApiResponse>(stringfyContent,
                 JsonSerializerSettingsBuilder.Build(new EmployeeContractResolver()));

            return employeeApiResponse?.Data;
        }
    }
    public record EmployeesGetAllApiResponse 
    {
        public List<Employee> Data { get; set; }
    }

    public record EmployeeGetApiResponse 
    {
        public Employee? Data { get; set; }
    }
}
