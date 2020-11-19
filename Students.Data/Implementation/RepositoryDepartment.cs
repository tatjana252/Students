using Students.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.Data.Implementation
{
    public class RepositoryDepartment : IRepositoryDepartment
    {
        private StudentsContext context;

        public RepositoryDepartment(StudentsContext context)
        {
            this.context = context;
        }

        public void Add(Department s)
        {
            context.Departments.Add(s);
            
        }

        public void Delete(Department s)
        {
            context.Departments.Remove(s);
        }

        public Department FindById(int id)
        {
            return context.Departments.Find(id); 
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

    }
}
