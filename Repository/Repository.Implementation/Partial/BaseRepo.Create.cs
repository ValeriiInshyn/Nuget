﻿using Microsoft.EntityFrameworkCore;

namespace Repository.Implementation;

public partial class BaseRepo<TContext, TEntity> where TEntity : class where TContext : DbContext
{
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await CreateNoSaveAsync(entity);
        await SaveChangesAsync();
        return entity;
    }


    public virtual async Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities)
    {
        var rangeAsync = entities.ToList();
        await DbSet.AddRangeAsync(rangeAsync);
        await SaveChangesAsync();
        return rangeAsync;
    }


    public virtual async Task CreateNoSaveAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }
}