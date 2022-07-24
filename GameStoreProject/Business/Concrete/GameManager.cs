using Business.Abstract;
using Core.Utilities.ResultTool;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class GameManager : IGameService
    {
        private readonly IGameService _gameService;

        public GameManager(IGameService gameService)
        {
            _gameService = gameService;
        }

        public IResult Add(Game game)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int gameId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Game>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Game> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
