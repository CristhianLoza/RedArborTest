using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ms_source_get.Domain.Contracts;
using ms_source_get.Domain.Dto;

namespace ms_source_get.Api.Controllers
{
    [Route("api/redarbor")]
    [ApiController]
    public class GetController : ControllerBase
    {
        private readonly ILogger<GetController> _logger;
        private readonly IGetRepositoy _getRepositoy;

        public GetController(ILogger<GetController> logger, IGetRepositoy getRepositoy)
        {
            _logger=logger;
            _getRepositoy=getRepositoy;
        }

        [HttpGet]
        public List<Employee> GetAll()
        {
            return _getRepositoy.GetAll();
        }

        [HttpGet("{id:int}")]
        public Employee GetAll(int id)
        {
            return _getRepositoy.GetAll(id);
        }
    }
}
