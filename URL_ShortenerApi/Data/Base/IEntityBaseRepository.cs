﻿using System.Linq.Expressions;
using URL_ShortenerApi.Models;

namespace URL_ShortenerApi.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class
    {
        Task<T> Get(Expression<Func<T, bool>>? filter, string? IncludeProperties = null, bool IsTracked = false);
        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter, string? IncludeProperties = null);
        Task Create(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}
