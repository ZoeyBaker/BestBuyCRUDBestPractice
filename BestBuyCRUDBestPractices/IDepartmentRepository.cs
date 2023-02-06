using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPractices
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
    }
}
