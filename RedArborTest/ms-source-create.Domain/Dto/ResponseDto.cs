using ms_source_create.Infraestructure.Entities.Employee;

namespace ms_source_create.Domain.Dto
{
    public class ResponseDto
    {
        public bool error { get; set; }
        public string state { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public Employee? employee { get; set; } 
    }
}
