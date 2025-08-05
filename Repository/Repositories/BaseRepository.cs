using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private static int _idCounter = 0;
        public void Create(T entity)
        {
            entity.Id = ++_idCounter;
            AppDbContext<T>.datas.Add(entity);
        }

        public void Delete(T entity)
        {
            AppDbContext<T>.datas.Remove(entity);
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return AppDbContext<T>.datas;
        }

        public List<T> GetAllWithExpression(Func<T, bool> predicate)
        {
            return AppDbContext<T>.datas.Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return AppDbContext<T>.datas.FirstOrDefault(m => m.Id == id);
        }
    }
}
