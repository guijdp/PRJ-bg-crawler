using System.Data.Entity;

namespace MFU_BGCrawler.DbModels
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}