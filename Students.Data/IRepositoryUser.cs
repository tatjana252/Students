using Students.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Data
{
    public interface IRepositoryUser : IRepository<User>
    {
        User GetByUsernameAndPassword(User user);
    }
}
