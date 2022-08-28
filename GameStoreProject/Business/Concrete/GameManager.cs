using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class GameManager : IGameService
    {
        private readonly IGameDal _gameDal;
        private readonly IMapper _mapper;
        private readonly IGameImageService _gameImageService;
        private readonly IFileTool _fileTool;

        public GameManager(IGameDal gameDal,
                           IMapper mapper,
                           IGameImageService gameImageService,
                           IFileTool fileTool)
        {
            _gameDal = gameDal;
            _mapper = mapper;
            _gameImageService = gameImageService;
            _fileTool = fileTool;
        }

        [ValidationAspect(typeof(GameValidator))]
        public IResult Add(Game game)
        {
            _gameDal.Add(game);
            return new SuccessResult();
        }

        public IResult Delete(int gameId)
        {
            var entity = _gameDal.Get(x => x.Id == gameId);
            _gameDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Game>> GetAll()
        {
            var result = _gameDal.GetAll();
            return new SuccessDataResult<List<Game>>(result);
        }

        public IDataResult<List<GameDto>> GetAllDto()
        {
            var listEntity = _gameDal.GetAll(null, x =>
            {
                return x.Include(s => s.Company)
                        .Include(s => s.Company)
                        .Include(s => s.Category);
            });
            var result = _mapper.Map<List<GameDto>>(listEntity);
            return new SuccessDataResult<List<GameDto>>(result);
        }

        public IDataResult<Game> GetById(int gameId)
        {
            var result = _gameDal.Get(x => x.Id == gameId);
            return new SuccessDataResult<Game>(result);
        }

        public IDataResult<GameDto> GetByIdDto(int gameId)
        {
            var entity = _gameDal.Get(x => x.Id == gameId, x =>
            {
                return x.Include(s => s.Company)
                        .Include(s => s.Company)
                        .Include(s => s.Category);
            });
            var result = _mapper.Map<GameDto>(entity);
            return new SuccessDataResult<GameDto>(result);
        }

        public IResult UploadImages(GameImageUploadDto gameImageDto)
        {
            var uploadResult = _fileTool.UploadCollection(gameImageDto.FileCollection);
            if (!uploadResult.Success) return uploadResult;

            var gameImages = (from fileName in uploadResult.Data
                              select new GameImage
                              {
                                  GameId = gameImageDto.GameId,
                                  ImagePath = fileName
                              }).ToList();

            var result = _gameImageService.AddList(gameImages);
            return result;
        }

        public IResult Update(Game game)
        {
            _gameDal.Update(game);
            return new SuccessResult();
        }
    }
}
