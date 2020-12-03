using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepositoryDepartment Department { get; set; }
        public IRepositoryStudent Student { get; set; }
        public IRepositorySubject Subject { get; set; }
        void Commit();
    }
}
