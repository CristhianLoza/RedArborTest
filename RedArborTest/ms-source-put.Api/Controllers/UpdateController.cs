using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ms_source_put.Domain.Contracts;
using ms_source_put.Infraestructure.Entities.Employee;

namespace ms_source_put.Api.Controllers
{
    [Route("api/redarbor")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly ILogger<UpdateController> _logger;
        private readonly IUpdateRepository _updateRepository;       

        public UpdateController(ILogger<UpdateController> logger, IUpdateRepository updateRepository)
        {
            _logger=logger;
            _updateRepository=updateRepository;
        }

        [HttpPut]
        public bool UpdateEmployee(Employee employee)
        {
            return _updateRepository.UpdateEmployee(employee);
        }
    }
}
