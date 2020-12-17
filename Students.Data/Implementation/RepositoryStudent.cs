using Students.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Students.Data.Implementation
{
    public class RepositoryStudent : IRepositoryStudent
    {
        private StudentsContext context;
        public RepositoryStudent(StudentsContext context)
        {
            this.context = context;
        }
        public void Add(Student s)
        {
            context.Add(s);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Student s)
        {
            throw new NotImplementedException();
        }

        public Student FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Subject> GetEnrolledSubject(Student s)
        {
            throw new NotImplementedException();
        }

        public List<Student> Search(Expression<Func<Student, bool>> pred)
        {
            throw new NotImplementedException();
        }
    }
}
