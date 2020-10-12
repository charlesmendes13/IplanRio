﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IplanRio.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
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
