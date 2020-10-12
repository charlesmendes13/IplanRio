﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IplanRio.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T GetById(object id);
        void Insert(T entidade);
        void Update(T entidade);
        void Delete(T entidade);
        int Commit();
        void Dispose();
    }
}
