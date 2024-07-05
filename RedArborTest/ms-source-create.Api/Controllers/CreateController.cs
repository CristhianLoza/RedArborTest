using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ms_source_create.Domain.Contracts;
using ms_source_create.Domain.Dto;
using ms_source_create.Infraestructure.Entities.Employee;

namespace ms_source_create.Api.Controllers
{
    [Route("api/redarbor")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        private readonly ILogger<CreateController> _logger;
        private readonly ICreateRepository _createRepository;

        public CreateController(ILogger<CreateController> logger, ICreateRepository createRepository)
        {
            _logger=logger;
            _createRepository=createRepository;
        }

        [HttpPost]
        public ResponseDto CreateEmployee(Employee employee)
        {
            return _createRepository.CreateEmployee(employee);
        }
    }
}
