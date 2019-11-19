﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ThingsWeNeed.Models;
using ThingsWeNeed.DAL;

namespace ThingsWeNeed.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TwnContext context;
        protected readonly DbSet<T> entities;

        public GenericRepository(TwnContext mc)
        {
            this.context = mc;
            entities = mc.Set<T>();
        }

        public void Delete(int id) => entities.Remove(entities.Find(id));

        public IEnumerable<T> GetAll() => entities.ToList();

        public T GetById(int id) => entities.Find(id);

        public void Insert(T toInsert) => entities.Add(toInsert);

        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
            return entities.Where(filter);
        }

        public IEnumerable<T> QueryObjectGraph(Expression<Func<T, bool>> filter, string children)
        {
            return entities.Include(children).Where(filter);
        }

    }
}