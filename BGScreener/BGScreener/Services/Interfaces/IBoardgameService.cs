using System;
using BGScreener.DbModels;
namespace BGScreener.Services.Interfaces
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
