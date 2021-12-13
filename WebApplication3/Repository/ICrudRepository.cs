﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Context;

namespace WebApplication3.Repository
{
    public interface ICrudRepository<T> where T : class
    {
        /*void DeleteById(Guid id);*/


        IEnumerable<T> GetAll();


        public T GetById(Guid id);
        public T Insert(T obj);
        public void Delete(Guid id);
        public int Save();
        public void Update(T obj);

    }
}
