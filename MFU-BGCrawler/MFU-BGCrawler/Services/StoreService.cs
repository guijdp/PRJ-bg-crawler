using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Services.Interfaces;
using System;
using System.Linq;

namespace MFU_BGCrawler.Services
{
    public class StoreService : IStoreService
    {
        private readonly BGSniperContext _repository;

        public StoreService(BGSniperContext repository)
        {
            _repository = repository;
        }

        public DbcStore[] Get()
        {
            return _repository.Store.ToArray();
        }

        public DbcStore Find(Guid id)
        {
            return _repository.Store.FirstOrDefault(s => s.Id == id);
        }

        public DbcStore Insert(Store store)
        {
            return new DbcStore();//todo
        }

        public DbcStore Update(DbcStore store)
        {
            return store;//todo
        }

        public DbcStore Delete(DbcStore store)
        {
            return store;//todo
        }
    }
}