using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Services.Interfaces;
using System.Linq;

namespace MFU_BGCrawler.Services
{
    public class StoreService : IStoreService
    {
        private readonly IRepository<Store> _storeRepository;

        public StoreService(IRepository<Store> storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public IQueryable<Store> GetStores()
        {
            return _storeRepository.Table;
        }

        public Store GetStore(long id)
        {
            return _storeRepository.GetById(id);
        }

        public void InsertStore(Store store)
        {
            _storeRepository.Insert(store);
        }

        public void UpdateStore(Store store)
        {
            _storeRepository.Update(store);
        }

        public void DeleteStore(Store store)
        {
            _storeRepository.Delete(store);
        }
    }
}