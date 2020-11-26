using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Domain
{
    public class StudentsContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Students;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Subject>().OwnsMany(s => s.Items);
            //modelBuilder.Entity<Subject>().HasKey(s => s.SId);
            modelBuilder.Entity<Subject>(s =>
            {
                s.OwnsMany(s => s.Items);
                s.HasKey(s => s.SId);
            });
            modelBuilder.Entity<Enrollment>(e =>
            {
                e.HasKey(e => new { e.StudentId, e.SubjectId });
                e.HasOne(e => e.Student).WithMany(s => s.Subjects).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Student>().Property(s => s.LastName).HasColumnName("Lastname");
            modelBuilder.Entity<Student>().Property(s => s.LastName).IsRequired(true);
            
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student{ StudentId = 1, FirstName = "Pera", LastName = "Peric", DateOfBirth = new DateTime(1996, 5, 8) }, 
                new Student { StudentId = 2, FirstName = "Mika", LastName = "Mikic", DateOfBirth = new DateTime(1998, 11, 8) });
        }
    }
}
