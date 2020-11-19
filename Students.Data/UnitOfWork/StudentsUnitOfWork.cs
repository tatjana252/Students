using Students.Data.Implementation;
using Students.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Data.UnitOfWork
{
    public class StudentsUnitOfWork : IUnitOfWork
    {
        private StudentsContext context;

        public StudentsUnitOfWork(StudentsContext context)
        {
            this.context = context;
            Department = new RepositoryDepartment(context);
            Student = new RepositoryStudent(context);
        }

        public IRepositoryDepartment Department { get; set; }
        public IRepositoryStudent Student { get; set; }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
