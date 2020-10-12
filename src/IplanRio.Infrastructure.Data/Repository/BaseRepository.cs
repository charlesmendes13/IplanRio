﻿using IplanRio.Domain.Interfaces.Repository;
using IplanRio.Infrastructure.Data.Context;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IplanRio.Infrastructure.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ContextIplanRio _context;

        public BaseRepository(ContextIplanRio context)
        {
            _context = context;
        }

        public IEnumerable<T> Get()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar: " + ex.Message);
            }
        }

        public T GetById(object id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar: " + ex.Message);
            }
        }

        public void Insert(T entidade)
        {
            try
            {
                _context.Set<T>().Add(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir: " + ex.Message);
            }
        }

        public void Update(T entidade)
        {
            try
            {
                _context.Entry(entidade).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Alterar: " + ex.Message);
            }
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Delete(T entidade)
        {
            try
            {
                _context.Set<T>().Remove(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir: " + ex.Message);
            }
        }

        #region

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        #endregion
    }
}
