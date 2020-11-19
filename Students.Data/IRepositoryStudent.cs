using Students.Domain;
using System;
using System.Collections.Generic;

namespace Students.Data
{
    public interface IRepositoryStudent : IRepository<Student>
    {
        List<Subject> GetEnrolledSubject(Student s);
    }
}
