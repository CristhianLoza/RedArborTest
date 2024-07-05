using ms_source_delete.Infraestructure.Entities.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_source_delete.Domain.Contracts
{
    public interface IDeleteRepository
    {
        bool DeleteEmployee(int id);
    }
}
