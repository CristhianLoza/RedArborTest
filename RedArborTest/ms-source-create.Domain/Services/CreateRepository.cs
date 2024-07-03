using ms_source_create.Infraestructure.Entities.Employee;
using ms_source_create.Domain.Contracts;
using Microsoft.Extensions.Logging;
namespace ms_source_create.Domain.Services
{
    public class CreateRepository: ICreateRepository
    {
        private readonly ILogger<CreateRepository> _logger;
        private readonly redarbordbContext _redarbordbContext;

        public CreateRepository(ILogger<CreateRepository> logger, redarbordbContext redarbordbContext) 
        {
            _redarbordbContext = redarbordbContext;
            _logger = logger;   
        }

        public Employee CreateEmployee(Employee employee)
        {
            try
            {
                _redarbordbContext.Employees.Add(employee);
                _redarbordbContext.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error CreateEmployee Employee {arg}", employee.Username);
                return employee;
            }
        }
    }
}
