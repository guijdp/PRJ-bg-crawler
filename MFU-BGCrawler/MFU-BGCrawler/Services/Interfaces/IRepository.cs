using MFU_BGCrawler.DbModels;
using System.Linq;

namespace MFU_BGCrawler.Services
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}

