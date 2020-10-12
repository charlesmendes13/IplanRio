﻿using IplanRio.Application.Interfaces;
using IplanRio.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IplanRio.Application.Services
{
    public class BaseAppService<T> : IBaseAppService<T> where T : class
    {
        private readonly IBaseService<T> _service;

        public BaseAppService(IBaseService<T> service)
        {
            _service = service;
        }

        public void Delete(T entidade)
        {
            _service.Delete(entidade);
        }

        public IEnumerable<T> Get()
        {
            return _service.Get();
        }

        public T GetById(object id)
        {
            return _service.GetById(id);
        }

        public void Insert(T entidade)
        {
            _service.Insert(entidade);
        }

        public void Update(T entidade)
        {
            _service.Update(entidade);
        }

        public int Commit()
        {
            return _service.Commit();
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
