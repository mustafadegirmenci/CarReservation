using CarReservation.Application.Repositories;
using CarReservation.Persistence.Context;
using CarReservation.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CarReservation.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly DataContext _context;

    protected BaseRepository(DataContext context)
    {
        _context = context;
    }
    
    public void Create(T entity)
    {
        _context.Add(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public Task<T?> Get(Guid id, CancellationToken cancellationToken)
    {
        return _context
            .Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<List<T>> GetMultiple(IEnumerable<Guid> ids, CancellationToken cancellationToken)
    {
        return _context
            .Set<T>()
            .Where(x => ids.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }

    public Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return _context
            .Set<T>()
            .ToListAsync(cancellationToken);
    }
}
