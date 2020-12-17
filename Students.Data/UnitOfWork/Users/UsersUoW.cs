using Students.Data.Implementation;
using Students.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Data.UnitOfWork.Users
{
    public class UsersUoW : IUsersUoW
    {
        private readonly UserContext context;

        public UsersUoW(UserContext context)
        {
            this.context = context;
            Users = new RepositoryUser(context);
        }

        public IRepositoryUser Users { get; set; }

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
