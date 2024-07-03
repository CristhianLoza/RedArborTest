using ms_source_create.Infraestructure.Entities.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_source_create.Domain.Contracts
{
    public interface ICreateRepository
    {
        Employee CreateEmployee(Employee employee);
    }
}
