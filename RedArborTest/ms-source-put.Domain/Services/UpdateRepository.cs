using Microsoft.Extensions.Logging;
using ms_source_put.Domain.Contracts;
using ms_source_put.Infraestructure.Entities.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_source_put.Domain.Services
{
    public class UpdateRepository: IUpdateRepository
    {
        private readonly ILogger<UpdateRepository> _logger;
        private readonly redarbordbContext _redarbordbContext;

        public UpdateRepository(ILogger<UpdateRepository> logger, redarbordbContext redarbordbContext)
        {
            _redarbordbContext = redarbordbContext;
            _logger = logger;
        }

        ///<summary>
        ///ACtualiza el empleado que se desea apartir de la clase employee
        ///</summary>
        ///<return>
        ///Devuelve un true si el empleado fue actualziado o un false si fallo o no actualizo 
        ///</return>
        ///<param name="employee">
        ///El empleado que se desea actualizar 
        ///</param>
        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                _redarbordbContext.Employees.Update(employee);
                _redarbordbContext.SaveChanges();

                SimpleEmitter.SendMessage(employee, MQSettingBuilder.Build(), "UpdateEmpleados");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error UpdateEmployee Employee {arg}", employee.Username);
                return false;
            }
        }
    }
}
