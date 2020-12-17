using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Data.UnitOfWork.Users
{
    public interface IUsersUoW : IDisposable
    {
        public IRepositoryUser Users { get; set; }

        void Commit();
    }
}
