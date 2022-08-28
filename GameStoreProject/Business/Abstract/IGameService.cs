using Core.Utilities.ResultTool;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IGameService
    {
        IDataResult<List<Game>> GetAll();
        IDataResult<Game> GetById(int gameId);
        IResult Add(Game game);
        IResult Update(Game game);
        IResult Delete(int gameId);



        IDataResult<List<GameDto>> GetAllDto();
        IDataResult<GameDto> GetByIdDto(int gameId);
        IResult UploadImages(GameImageUploadDto gameImageDto);
    }
}
