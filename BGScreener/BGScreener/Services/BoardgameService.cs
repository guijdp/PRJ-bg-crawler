using System;
using System.Linq;
using BGScreener.DbModels;
using BGScreener.Services.Interfaces;

namespace BGScreener.Services
{
    public class BoardgameService : IBoardgameService
    {
        private readonly BGSniperContext _repository;

        public BoardgameService(BGSniperContext repository)
        {
            _repository = repository;
        }

        public BoardgameDTO[] Get()
        {
            return _repository.Boardgame.ToArray();
        }

        public BoardgameDTO Find(Guid id)
        {
            return _repository.Boardgame.FirstOrDefault(c => c.Id == id);
        }

        public BoardgameDTO Insert(BoardgameDTO boardGame)
        {
            return new BoardgameDTO();//todo
        }

        public BoardgameDTO Update(BoardgameDTO boardGame)
        {
            return new BoardgameDTO();//todo
        }

        public BoardgameDTO Delete(BoardgameDTO boardGame)
        {
            return new BoardgameDTO();//todo
        }
    }
}
