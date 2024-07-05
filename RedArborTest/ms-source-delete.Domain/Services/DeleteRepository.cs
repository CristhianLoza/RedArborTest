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

        ///<summary>
        ///Elimina un empleado de la tabla employee
        ///</summary>
        ///<return>
        ///Devuelve un true si el empleado fue eliminado o un false si fallo o no Elimino 
        ///</return>
        ///<param name="id">
        ///El UserId del empleado que se desea eliminar
        ///</param>
        public bool DeleteEmployee(int id)
        {
            try
            {
                var employee = _redarbordbContext.Employees.FirstOrDefault(x=>x.UserId == id);
                _redarbordbContext.Employees.Remove(employee);
                _redarbordbContext.SaveChanges();

                SimpleEmitter.SendMessage(employee, MQSettingBuilder.Build(), "DeleteEmpleados");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error DeleteEmployee Employee {arg}", id);
                return false;
            }
        }
    }
}
