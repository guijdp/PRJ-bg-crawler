using System;
using System.Linq;
using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Services.Interfaces;

namespace MFU_BGCrawler.Services
{
    public class BoardgameService : IBoardgameService
    {
        private readonly BGSniperContext _repository;

        public BoardgameService(BGSniperContext repository)
        {
            _repository = repository;
        }

        public DbcBoardgame[] Get()
        {
            return _repository.Boardgame.ToArray();
        }

        public DbcBoardgame Find(Guid id)
        {
            return _repository.Boardgame.FirstOrDefault(c => c.Id == id);
        }

        public DbcBoardgame Insert(DbcBoardgame boardGame)
        {
            return new DbcBoardgame();//todo
        }

        public DbcBoardgame Update(DbcBoardgame boardGame)
        {
            return new DbcBoardgame();//todo
        }

        public DbcBoardgame Delete(DbcBoardgame boardGame)
        {
            return new DbcBoardgame();//todo
        }
    }
}
