using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Service
{
    public interface IService<TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAsync(int id); //id'ye göre nesne getir. 

        Task<IEnumerable<TEntity>> GetAllAsync(); //Tüm nesneleri getir. 

        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);//Parametreye göre ilgili nsneleri getir.

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate); //Örneğin product'ın innerbarcode'u şu olanı getir.

        Task<TEntity> AddAsync(TEntity entity);//ekleme işlemi

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);//Toplu ekleme işlemi

        void Remove(TEntity entity); //Silme işlemi
        void RemoveRange(IEnumerable<TEntity> entities);//Toplu silme

        TEntity Update(TEntity entity);//Güncelleme işlemi
    }
}
