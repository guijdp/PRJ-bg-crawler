using System;
using BGScreener.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace BGScreener.Services.Interfaces
{
    public interface IStoreService
    {
        StoreDTO[] Get();
        StoreDTO Find(Guid id);
        StoreDTO Insert(Store store);
        StoreDTO Update(StoreDTO store);
        StoreDTO Delete(StoreDTO store);
    }
}
