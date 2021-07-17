using System;
using System.Linq;
using AutoMapper;
using BGScreener.DbModels;
using BGScreener.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public StoreDTO[] Get() => _repository.Store.OrderBy(s => s.Name)
            .Include(s => s.Country).ToArray();

        public StoreDTO Find(Guid id) => _repository.Store.FirstOrDefault(s => s.Id == id);

        public StoreDTO Insert(Store store)
        {
            try
            {
                var model = _mapper.Map<StoreDTO>(store);
                var country = _repository.Country.FirstOrDefault(s => s.Name == store.Country);
                model.Country = country ?? model.Country;

                var result = _repository.Store.Add(model).Entity;
                _repository.SaveChanges();

                return result;
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
                _repository.Store.Attach(store).Property(x => x.Name).IsModified = true;
                _repository.SaveChanges();
                return store;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                throw ex.InnerException;
            }
        }

        public StoreDTO Delete(StoreDTO store)
        {
            try
            {
                _repository.Store.Remove(store);
                _repository.SaveChanges();
                return store;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                throw ex;
            }
        }
    }
}