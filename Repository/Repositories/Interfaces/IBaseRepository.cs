using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        void Edit(T entity);
        T GetById(int id);
        List<T> GetAll();
        List<T> GetAllWithExpression(Func<T,bool>predicate);
    }
}
