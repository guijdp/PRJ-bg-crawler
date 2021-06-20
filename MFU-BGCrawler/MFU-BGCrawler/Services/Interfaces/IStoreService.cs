using System;
using MFU_BGCrawler.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace MFU_BGCrawler.Services.Interfaces
{
    public interface IStoreService
    {
        Store[] Get();
        DbcStore Find(Guid id);
        DbcStore Insert(Store store);
        DbcStore Update(DbcStore store);
        DbcStore Delete(DbcStore store);
    }
}
