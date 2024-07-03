using Microsoft.Extensions.Logging;
using ms_source_delete.Domain.Contracts;
using ms_source_delete.Infraestructure.Entities.Employee;

namespace ms_source_delete.Domain.Services
{
    public class DeleteRepository : IDeleteRepository
    {
        private readonly ILogger<DeleteRepository> _logger;
        private readonly redarbordbContext _redarbordbContext;

        public DeleteRepository(ILogger<DeleteRepository> logger,redarbordbContext context)
        {
            _logger = logger;
            _redarbordbContext = context;
        }

        public int DeleteEmployee(Employee employee)
        {
            try
            {
                _redarbordbContext.Employees.Remove(employee);
                _redarbordbContext.SaveChanges();
                return employee.UserId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error CreateEmployee Employee {arg}", employee.Username);
                return employee.UserId;
            }
        }
    }
}
