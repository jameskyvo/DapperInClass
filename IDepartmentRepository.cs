using System;
using System.Collections.Generic;

namespace DapperInClass
{
    internal interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
    }
}
