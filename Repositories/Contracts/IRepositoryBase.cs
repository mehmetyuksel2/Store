using System.Linq.Expressions;

namespace Repositories.Contracts
{//buradaki metodlar genel tabir ile yazılır
    public interface IRepositoryBase<T>
    {
         IQueryable<T> FindAll(bool trackChanges);
         T? FindByCondition(Expression<Func<T,bool>> expression, bool trackChanges);
         void Create(T entity);
        void Remove(T entity);//ProductRepository de kullanılması için burada arayüz tanımı gerçekleştiriliyoruz
        void Update(T entity);
    }
}