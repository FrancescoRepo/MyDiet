using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Business.IRepository
{
    public interface IRepository<T>
    {
        public Task<IList<T>> GetAll();
        public Task<T> Get(int id);
        public Task Create(T entity);
        public Task Update(int id, T entity);
        public Task Delete(int id);
    }
}
