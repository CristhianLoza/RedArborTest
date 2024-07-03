using Microsoft.AspNetCore.Mvc;
using ms_source_delete.Domain.Contracts;
using ms_source_delete.Infraestructure.Entities.Employee;

namespace ms_source_delete.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly ILogger<DeleteController> _logger;
        private readonly IDeleteRepository _deleteRepository;

        public DeleteController(ILogger<DeleteController> logger, IDeleteRepository deleteRepository)
        {
            _logger=logger;
            _deleteRepository=deleteRepository;
        }

        [HttpPost]
        public int DeleteEmployee(Employee employee)
        {
            return _deleteRepository.DeleteEmployee(employee);
        }
    }
}
