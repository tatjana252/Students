using Students.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.Data.Implementation
{
    public class RepositorySubject : IRepositorySubject
    {
        private readonly StudentsContext context;

        public RepositorySubject(StudentsContext context)
        {
            this.context = context;
        }

        public void Add(Subject s)
        {
            throw new NotImplementedException();
        }

        public void Delete(Subject s)
        {
            throw new NotImplementedException();
        }

        public Subject FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Subject> GetAll()
        {
            return context.Subjects.ToList();
        }
    }
}
