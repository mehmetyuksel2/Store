using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class, new()
    {

        protected readonly RepositoryContext _context;
        //IRepositoryBase soyutlanmış metodlardan ibarettir.
        //eğer bu sınıftan türetiliyor ise altındaki tüm
        //soyutlanmış metodları implemente etmek zorundayız
        //**
        //<T> değişkenide yerine her türden generik bir obje gelebileceğini
        //belirtir

        protected RepositoryBase(RepositoryContext context){//base classımız burası olduğu için contex nesnemizi burada oluşturuyoruz
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? _context.Set<T>()
                : _context.Set<T>().AsNoTracking();
                //trackchanges true ise
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? _context.Set<T>().Where(expression).SingleOrDefault()
                : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public void Remove(T entity)//ProductRepositoryde kullanılması için burada implemente ediyoruz
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }

    public interface IRepositoryBase
    {
    }
}