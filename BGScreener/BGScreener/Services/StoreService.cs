using AutoMapper;
using BGScreener.DbModels;
using BGScreener.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BGScreener.Services
{
    public class StoreService : IStoreService
    {
        private readonly BGScreenerContext _repository;
        private readonly IMapper _mapper;

        public StoreService(BGScreenerContext storeRepository, IMapper mapper)
        {
            _repository = storeRepository;
            _mapper = mapper;
        }

        public StoreDTO[] Get() => _repository.Store.Include(s => s.Country).ToArray();

        public StoreDTO Find(Guid id) => _repository.Store.FirstOrDefault(s => s.Id == id);

        public StoreDTO Insert(Store store)
        {
            try
            {
                var country = _repository.Country.FirstOrDefault(c => c.CountryName == store.Country);
                if (country == null)
                    throw new Exception($"Country named {store.Country} does not exist");

                var entry = new StoreDTO()
                {
                    Name = store.Name,
                    Country = country
                };

                _repository.Store.Add(entry);
                _repository.SaveChanges();

                return entry;
            }
            catch (Exception e)
            {
                //Todo: Log error here
                throw e;
            }
        }

        public StoreDTO Update(StoreDTO store)
        {
            try
            {
                var entry = Find(store.Id);
                if (store == null)
                    throw new Exception($"Store with Id {store.Id} does not exist");

                var country = _repository.Country.FirstOrDefault(c => c.CountryName == store.Name);
                if (country == null)
                    throw new Exception($"Country named {store.Country} does not exist");


                _repository.Store.Attach(entry);
                entry.ModifiedDate = DateTime.UtcNow;
                entry.Name = store.Name;
                _repository.SaveChanges();
                return entry;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                throw ex;
            }
        }

        public StoreDTO Delete(StoreDTO store)
        {
            var entry = Find(store.Id);
            if (entry == null)
                throw new Exception($"Store with Id {store.Id} does not exist");

            try
            {
                _repository.Store.Remove(entry);
                _repository.SaveChanges();
                return store;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                _repository.Entry(entry).Reload();
                throw ex.InnerException;
            }
        }
    }
}