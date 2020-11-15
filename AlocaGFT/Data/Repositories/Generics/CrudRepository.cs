using System;
using System.Collections.Generic;
using System.Linq;
using AlocaGFT.Interfaces.Generics;
using AlocaGFT.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data.Repositories.Generics
{
    public abstract class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        protected readonly AlocaGFTDbContext _context;
        public CrudRepository(AlocaGFTDbContext context)
        {
            this._context = context;
        }

        public virtual void DeletarPorId(long id)
        {
            T entity = GetPorId(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void DesativarPorId(long id)
        {
            T entity = GetPorId(id);
            if (entity == null || typeof(T)! is IDefaultCrudEntity) throw new NullReferenceException($"{typeof(T).Name} inválida(o)!");

            var defaultCrudIdentity = (IDefaultCrudEntity)entity;
            defaultCrudIdentity.status = false;
            _context.SaveChanges();
        }

        public virtual T GetPorId(long id)
        {
            T entity = _context.Set<T>().Find(id);
            if (entity == null) throw new EntidadeNaoEncontradaException($"{typeof(T).Name} não encontrada(o)!");
            return entity;
        }

        public virtual List<T> GetTodosAtivos()
        {
            List<T> entities = _context.Set<T>().ToList();
            return entities.Where(entity =>
            {
                if (entity is IDefaultCrudEntity)
                {
                    var defaultCrudIdentity = (IDefaultCrudEntity)entity;

                    return defaultCrudIdentity.status.Value;
                }
                else
                {
                    return true;
                }
            }).ToList();
        }

        public virtual T Salvar(T entity)
        {
            if (entity == null || typeof(T)! is IDefaultCrudEntity) throw new NullReferenceException($"{typeof(T).Name} inválida(o)!");

            var defaultCrudIdentity = (IDefaultCrudEntity)entity;
            var state = defaultCrudIdentity.HasId ? EntityState.Modified : EntityState.Added;

            _context.Entry(entity).State = state;
            _context.SaveChanges();
            return entity;
        }
    }
}