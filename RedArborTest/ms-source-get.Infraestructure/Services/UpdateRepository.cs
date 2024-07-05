using Microsoft.Extensions.Logging;
using ms_source_get.Domain.Dto;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using ms_source_get.Domain.Contracts;

namespace ms_source_get.Infraestructure.Services
{
    public class UpdateRepository: IUpdateRepository
    {
        private readonly ILogger<UpdateRepository> _logger;

        public UpdateRepository(ILogger<UpdateRepository> logger)
        {
            _logger = logger;
        }

        ///<summary>
        ///ACtualiza el empleado que se desea apartir de la clase employee
        ///</summary>
        ///<return>
        ///No devuelve ningun valor 
        ///</return>
        ///<param name="employee">
        ///El empleado que se desea actualizar 
        ///</param>
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                var connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=redarbordbtest;TrustServerCertificate=true;";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Update(employee);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error UpdateEmployee Employee {arg}", employee.Username);
            }
        }
    }
}
