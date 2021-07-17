using System;
using BGScreener.DbModels;
using BGScreener.Model;

namespace BGScreener.Services.Interfaces
{
    public interface IBoardgameService
    {
        BoardgameDTO[] Get();
        BoardgameDTO Find(Guid id);
        BoardgameDTO Insert(Boardgame country);
        BoardgameDTO Update(BoardgameDTO country);
        BoardgameDTO Delete(BoardgameDTO country);
    }
}
