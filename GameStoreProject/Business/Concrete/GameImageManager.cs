using Business.Abstract;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GameImageManager : IGameImageService
    {
        private readonly IGameImageDal _gameImageDal;

        public GameImageManager(IGameImageDal gameImageDal)
        {
            _gameImageDal = gameImageDal;
        }

        public IResult Add(GameImage gameImage)
        {
            _gameImageDal.Add(gameImage);
            return new SuccessResult();
        }

        public IResult AddList(List<GameImage> gameImages)
        {
            _gameImageDal.AddList(gameImages);
            return new SuccessResult();
        }

        public IResult Delete(int gameImageId)
        {
            var entity = _gameImageDal.Get(x => x.Id == gameImageId);
            _gameImageDal.Delete(entity);
            return new SuccessResult();
        }

        public IResult DeleteByGameId(int gameId)
        {
            var entities = _gameImageDal.GetAll(x => x.GameId == gameId);
            _gameImageDal.DeleteList(entities);
            return new SuccessResult();
        }

        public IDataResult<List<GameImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<GameImage> GetById(int gameImageId)
        {
            throw new NotImplementedException();
        }
    }
}
