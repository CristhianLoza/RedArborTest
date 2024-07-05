using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using ms_source_get.Domain.Contracts;
using ms_source_get.Domain.Dto;

namespace ms_source_get.Domain.Services
{
    public class InsertRepository : IInsertRepository
    {
        private readonly ILogger<InsertRepository> _logger;

        public InsertRepository(ILogger<InsertRepository> logger)
        {
            _logger = logger;
        }

        public void CreateEmployee(Employee employee)
        {
            try
            {
                var connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=redarbordbtest;TrustServerCertificate=true;";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Insert(employee);                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error CreateEmployee Employee {arg}", employee.Username);
            }
        }

    }
}
