using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using ms_source_get.Domain.Contracts;
using Dapper;
using ms_source_get.Domain.Dto;


namespace ms_source_get.Domain.Services
{
    public class GetRepository : IGetRepositoy
    {
        private readonly ILogger<GetRepository> _logger;
        public GetRepository(ILogger<GetRepository> logger)
        {
            _logger = logger;
        }

        ///<summary>
        ///Obtene lista de todos los employees
        ///</summary>
        ///<return>
        ///Devuelve toda la lista de los empleados 
        ///</return>
        public List<Employee> GetAll()
        {
            try
            {
                var connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=redarbordbtest;TrustServerCertificate=true;";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var sql = "SELECT * FROM Employee";

                    var employee = connection.Query<Employee>(sql);

                    return employee.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error GetAll Employee");
                return new List<Employee>();
            }
        }

        ///<summary>
        ///Obtene lista de todos los employees por userid
        ///</summary>
        ///<return>
        ///Devuelve el empleado solictiado apartir del userid
        ///</return>
        ///<param name="id">
        ///Es el UserId de la persona 
        ///</param>
        public Employee GetAll(int id)
        {
            try
            {
                var connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=redarbordbtest;TrustServerCertificate=true;";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var sql = "SELECT * FROM Employee where UserId = " + id;

                    var employee = connection.Query<Employee>(sql);

                    return employee.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error GetAll Employee");
                return new Employee();
            }
        }
    }
}
