using System;
using MFU_BGCrawler.DbModels;

namespace MFU_BGCrawler.Services.Interfaces
{
    public interface IStoreService
    {
        DbcStore[] Get();
        DbcStore Find(Guid id);
        DbcStore Insert(Store store);
        DbcStore Update(DbcStore store);
        DbcStore Delete(DbcStore store);
    }
}
