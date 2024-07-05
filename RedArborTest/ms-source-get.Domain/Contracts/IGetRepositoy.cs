using ms_source_get.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_source_get.Domain.Contracts
{
    public interface IGetRepositoy
    {
        List<Employee> GetAll();
        Employee GetAll(int id);
    }
}
