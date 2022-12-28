using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.EntityFramework.Services;

public class GenericDataService<T> : IDataService<T> where T : DomainObject
{
    private readonly SimpleTraderDbContextFactory _contextFactory;

    public GenericDataService(SimpleTraderDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
        {
            return await context.Set<T>().ToListAsync();
        }
    }

    public async Task<T> Get(int id)
    {
        using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
        {
            return await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }
    }

    public async Task<T> Create(T entity)
    {
        using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
        {
            var createdEntity = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return createdEntity.Entity;
        }
    }

    public async Task<T> Update(int id, T entity)
    {
        using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
        {
            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }

    public async Task<bool> Delete(int id)
    {
        using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
        {
            T entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }
    }
}