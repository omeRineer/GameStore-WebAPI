using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Authorizaton;
using Core.Aspects.Validation;
using Core.Utilities.Identities.Claims;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class GameManager : IGameService
    {
        private readonly IGameDal _gameDal;

        public GameManager(IGameDal gameDal)
        {
            _gameDal = gameDal;
        }

        [ValidationAspect(typeof(GameValidator))]
        public IResult Add(Game game)
        {
            _gameDal.Add(game);
            return new SuccessResult();
        }

        public IResult Delete(int gameId)
        {
            var entity=_gameDal.Get(x=>x.Id == gameId);
            _gameDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Game>> GetAll()
        {
            var result = _gameDal.GetAll();
            return new SuccessDataResult<List<Game>>(result);
        }

        public IDataResult<Game> GetById(int id)
        {
            var result=_gameDal.Get(x=>x.Id==id);
            return new SuccessDataResult<Game>(result);
        }

        public IResult Update(Game game)
        {
            _gameDal.Update(game);
            return new SuccessResult();
        }
    }
}
