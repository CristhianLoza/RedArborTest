using Microsoft.AspNetCore.Mvc;
using ms_source_delete.Domain.Contracts;
using ms_source_delete.Infraestructure.Entities.Employee;

namespace ms_source_delete.Api.Controllers
{
    [Route("api/redarbor")]
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

        [HttpDelete("{id:int}")]
        public bool DeleteEmployees(int id)
        {
            return _deleteRepository.DeleteEmployee(id);
        }
    }
}
