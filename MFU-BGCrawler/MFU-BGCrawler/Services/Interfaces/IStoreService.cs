using System;
using MFU_BGCrawler.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace MFU_BGCrawler.Services.Interfaces
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
