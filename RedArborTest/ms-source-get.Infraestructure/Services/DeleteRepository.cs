using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using ms_source_get.Domain.Contracts;
using ms_source_get.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_source_get.Infraestructure.Services
{
    public class DeleteRepository:IDeleteRepository
    {
        private readonly ILogger<DeleteRepository> _logger;

        public DeleteRepository(ILogger<DeleteRepository> logger)
        {
            _logger = logger;
        }

        ///<summary>
        ///Elimina un empleado de la tabla employee
        ///</summary>
        ///<return>
        ///No devuelve nada 
        ///</return>
        ///<param name="id">
        ///El UserId del empleado que se desea eliminar
        ///</param>
        public void DeleteEmployee(Employee employee)
        {
            try
            {
                var connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=redarbordbtest;TrustServerCertificate=true;";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Delete(employee);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error DeleteEmployee Employee {arg}", employee.Username);                
            }
        }
    }
}
