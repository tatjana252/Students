using System;
using System.Collections.Generic;

namespace Students.Domain
{
    public class Student : IEntity
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Enrollment> Subjects { get; set; }

        public void Print()
        {
            Console.WriteLine(this);
        }

        // public List<Subject> Subjects { get; set; }
    }

}
