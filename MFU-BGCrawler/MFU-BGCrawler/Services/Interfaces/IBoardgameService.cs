using System;
using MFU_BGCrawler.DbModels;
namespace MFU_BGCrawler.Services.Interfaces
{
    public interface IBoardgameService
    {
        BoardgameDTO[] Get();
        BoardgameDTO Find(Guid id);
        BoardgameDTO Insert(BoardgameDTO country);
        BoardgameDTO Update(BoardgameDTO country);
        BoardgameDTO Delete(BoardgameDTO country);
    }
}
