using ms_source_create.Infraestructure.Entities.Employee;
using ms_source_create.Domain.Contracts;
using Microsoft.Extensions.Logging;
using ms_source_create.Domain.Dto;
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


        ///<summary>
        ///Inserta un empleado en la base de datos 
        ///</summary>
        ///<return>
        ///Devuelve una clase la cual contiene datos informativos y el rsultado
        ///</return>
        ///<param name="employee">
        ///El empleado que se desea insertar 
        ///</param>
        public ResponseDto CreateEmployee(Employee employee)
        {
            try
            {
                var validate = validateFields(employee);
                if (!string.IsNullOrEmpty(validate))
                {
                    _redarbordbContext.Employees.Add(employee);
                    _redarbordbContext.SaveChanges();
                    SimpleEmitter.SendMessage(employee, MQSettingBuilder.Build(), "CreateEmpleados");
                    return new ResponseDto
                    {
                        employee = employee,
                        error = false,
                        message = "Employee is create",
                        state = "200"
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        employee = employee,
                        error = false,
                        message = "Employee is create",
                        state = "602"
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error CreateEmployee Employee {arg}", employee.Username);
                return new ResponseDto
                {                    
                    error = true,
                    message = ex.Message,
                    state = "601"
                };
            }
        }

        public string validateFields(Employee employee)
        {
            try
            {
                if (employee == null)
                    return "No ingreso los campos completos";
                if (employee.CompanyId == 0)
                    return "Falta ingresar la informacion de CompanyId";
                if (string.IsNullOrEmpty(employee.Email))
                    return "Falta ingresar la informacion de Email";
                if (string.IsNullOrEmpty(employee.Password))
                    return "Falta ingresar la informacion de Password";
                if (employee.PortalId == 0)
                    return "Falta ingresar la informacion de PortalId";
                if (employee.RoleId == 0)
                    return "Falta ingresar la informacion de RoleId";
                if (employee.StatusId == 0)
                    return "Falta ingresar la informacion de StatusId";
                if (string.IsNullOrEmpty(employee.Username))
                    return "Falta ingresar la informacion de Username";

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error CreateEmployee Employee {arg}", employee.Username);                
            }
            return "";
        }
    }
}
