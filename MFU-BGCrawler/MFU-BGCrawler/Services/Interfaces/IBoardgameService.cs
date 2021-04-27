﻿using MFU_BGCrawler.DbModels;
namespace MFU_BGCrawler.Services.Interfaces
{
    public interface IBoardgameService
    {
        DbcBoardgame[] Get();
        DbcBoardgame Find(long id);
        DbcBoardgame Insert(DbcBoardgame country);
        DbcBoardgame Update(DbcBoardgame country);
        DbcBoardgame Delete(DbcBoardgame country);
    }
}