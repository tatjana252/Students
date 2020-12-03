using Students.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Students.Data
{
    public interface IRepositoryDepartment : IRepository<Department>
    {
        List<Department> Search(Expression<Func<Department, bool>> p);
    }


}
