using MFU_BGCrawler.DbModels;
using System.Linq;

namespace MFU_BGCrawler.Services.Interfaces
{
    public interface IStoreService
    {
        IQueryable<Store> GetStores();
        Store GetStore(long id);
        void InsertStore(Store user);
        void UpdateStore(Store user);
        void DeleteStore(Store user);
    }
}
