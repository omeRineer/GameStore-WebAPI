using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Authorizaton;
using Core.Aspects.Validation;
using Core.Utilities.Identities.Claims;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class GameManager : IGameService
    {
        private readonly IGameDal _gameDal;
        private readonly IMapper _mapper;

        public GameManager(IGameDal gameDal,
                           IMapper mapper)
        {
            _gameDal = gameDal;
            _mapper = mapper;
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
            var result = _gameDal.GetAll(null, x =>
            {
                return x.Include(x => x.Category)
                        .Include(s => s.Developer)
                        .Include(s => s.Distributor);
            });

            return new SuccessDataResult<List<Game>>(result);
        }

        public IDataResult<List<GameDto>> GetAllDto()
        {
            var listEntity = _gameDal.GetAll(null, x =>
            {
                return x.Include(s => s.Developer)
                        .Include(s=>s.Distributor)
                        .Include(s => s.Category);
            });
            var result=_mapper.Map<List<GameDto>>(listEntity);
            return new SuccessDataResult<List<GameDto>>(result);

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
