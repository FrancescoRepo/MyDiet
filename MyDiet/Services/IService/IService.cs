using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Services.IService
{
    public interface IService<T>
    {
        public Task<IList<T>> GetAll();
        public Task<T> Get(int id);
        public Task Create(T entityDto);
        public Task Update(int id, T entityDto);
        public Task Delete(int id);
    }
}
