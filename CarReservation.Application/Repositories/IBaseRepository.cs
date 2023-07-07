using CarReservation.Domain.Common;

namespace CarReservation.Application.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    public void Create(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    public Task<T?> Get(Guid id, CancellationToken cancellationToken);
    public Task<List<T>> GetAll(CancellationToken cancellationToken);
}
