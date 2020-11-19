using Students.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Data
{
    public interface IRepository<T>
    {
        void Add(T s);
        List<T> GetAll();
        T FindById(int id);
        void Delete(T s);
    }


   
}
