using ms_source_put.Infraestructure.Entities.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_source_put.Domain.Contracts
{
    public interface IUpdateRepository
    {
        bool UpdateEmployee(Employee employee);
    }
}
