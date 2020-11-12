using Microsoft.EntityFrameworkCore;
using Students.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Students.ConsoleApp
{
    //View/Other Windows/PackageManagerConsole
    class Program
    {
        static StudentsContext context = new StudentsContext();

        static void Main(string[] args)
        {
            AddSubjectItemToSubjectNoTracking();
            context.Dispose();
        }

        #region department
        public static void AddDepartments()
        {
            Department department = new Department { Name = "Katedrav za SI" };
            StudentsContext context = new StudentsContext();
            //context.Add(new Department { Name = "Katedra za IT" });
            //context.Add(new Department { Name = "Katedra za IS" });
            //context.Add(new Department { Name = "Katedra za OI" });
            //context.Add(new Department { Name = "Katedra za M" });
            context.Add(department);
            context.SaveChanges();
            context.Dispose();
        }
        public static void GetAllDepartments()
        {
            using StudentsContext context = new StudentsContext();
            List<Department> result = context.Departments.ToList();
            result.ForEach(d => Console.WriteLine(d));
        }

        public static void GetAllDepartmentsWhere()
        {
            using StudentsContext context = new StudentsContext();
            List<Department> result = context.Departments.Where(d => d.Name.Contains("SI")).ToList();
            result.ForEach(d => Console.WriteLine(d));
        }

        public static void UpdateTracking()
        {
            List<Department> departments = context.Departments.ToList();
            Department update = departments[1];
            update.Name = "Katedra za softversko inzenjerstvo";
            context.SaveChanges();
        }

        public static void UpdateNoTracking()
        {
            Department update = new Department { DepartmentId = 3, Name = "Katedra za informacione tehnologije" };
            //update.Name = "Katedra za informacione tehnologije";
            context.Update(update);
            context.SaveChanges();
        }
        #endregion

        #region subject
        public static void AddSubject()
        {
            int id = 1;
            Department department = context.Departments.Single(d => d.DepartmentId == id);
            Subject s = new Subject
            {
                Name = "Napredne .NET tehnologije",
                ESPB = 6,
                DepartmentId = 2
            };
            context.Add(s);
            context.SaveChanges();
        }

        public static void UpdateSubject()
        {
            Subject s = context.Subjects.Find(1);
            s.DepartmentId = 2;
            context.SaveChanges();
        }

        public static void GetAllSubjects()
        {
            List<Subject> subjectsWithDepartment = context.Subjects.Include(s => s.Department).ToList();
            subjectsWithDepartment.ForEach(s => Console.WriteLine(s));
        }

        public static void UpdateSubjectsDepartmentTracking()
        {
            List<Subject> subjectsWithDepartment = context.Subjects.Include(s => s.Department).ToList();
            Subject s = subjectsWithDepartment[0];
            s.Department.Name = "Department Update";
            context.SaveChanges();
        }

        public static void UpdateSubjectWithDepartmentNoTracking()
        {
            List<Subject> subjectsWithDepartment = context.Subjects.Include(s => s.Department).ToList();

            using StudentsContext newcontext = new StudentsContext();
            Subject s = subjectsWithDepartment[0];
            s.Department.Name = "Department Update No Tracking";
            newcontext.Update(s);
            newcontext.SaveChanges();
        } 

        public static void UpdateOnlyDepartmentNoTracking()
        {
            List<Subject> subjectsWithDepartment = context.Subjects.Include(s => s.Department).ToList();

            using StudentsContext newcontext = new StudentsContext();
            Subject s = subjectsWithDepartment[0];
            s.Department.Name = "Department Update No Tracking";

            newcontext.Attach(s);
            newcontext.Entry(s.Department).State = EntityState.Modified;
            newcontext.SaveChanges();
        }
        #endregion

        public static void AddSubjectWithItems()
        {
            Subject subject = new Subject
            {
                Name = "Projektovanje softvera",
                ESPB = 6,
                DepartmentId = 2,
                Items = new List<SubjectItem> {
                new SubjectItem{ Name = "Vezbe 1" },
                new SubjectItem{ Name = "Vezbe 2" },
                new SubjectItem{ Name = "Vezbe 3" },
                new SubjectItem{ Name = "Vezbe 4" },
                }
            };
            context.Add(subject);
            context.SaveChanges();
        }

        public static void AddSubjectItemToSubject()
        {
            Subject s = context.Subjects.Include(s => s.Items).First();
            s.Items.Add(new SubjectItem { Name = "Vezbe 5" });
            context.SaveChanges();
        }

        public static void AddSubjectItemToSubjectNoTracking()
        {
            Subject s = context.Subjects.First();
            s.Items.Add(new SubjectItem { Name = "Vezbe 10" });
            using StudentsContext newcontext = new StudentsContext();
            newcontext.Update(s); //posto slab objekat ima slozen kljuc, on nije generisan i onda je za njega state modified
            newcontext.Entry(s.Items.Single(i => i.Name == "Vezbe 10")).State = EntityState.Added; //moramo da promenimo state na update
            newcontext.SaveChanges();
        }
    }
}
