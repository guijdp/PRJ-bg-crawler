using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BGScreener.DbModels;
using BGScreener.Model;
using BGScreener.Services.Interfaces;

namespace BGScreener.Services
{
    public class BoardgameService : IBoardgameService
    {
        private readonly BGScreenerContext _repository;
        private readonly IMapper _mapper;

        public BoardgameService(BGScreenerContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public BoardgameDTO[] Get() =>
            _repository.Boardgame.OrderBy(bg => bg.Name).ToArray();

        public BoardgameDTO Find(Guid id) => _repository.Boardgame.FirstOrDefault(c => c.Id == id);

        public BoardgameDTO Insert(Boardgame boardGame)
        {
            try
            {
                var model = _mapper.Map<BoardgameDTO>(boardGame);
                var result = _repository.Boardgame.Add(model).Entity;
                _repository.SaveChanges();

                return result;
            }
            catch (Exception e)
            {
                //Todo: Log error here
                throw e;
            }
        }

        public BoardgameDTO Update(BoardgameDTO boardGame)
        {
            try
            {
                _repository.Boardgame.Attach(boardGame).Property(x => x.Name).IsModified = true;
                _repository.SaveChanges();
                return boardGame;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                throw ex.InnerException;
            }
        }

        public BoardgameDTO Delete(BoardgameDTO boardGame)
        {
            try
            {
                _repository.Boardgame.Remove(boardGame);
                _repository.SaveChanges();
                return boardGame;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                throw ex;
            }
        }
    }
}
