using Core.Utilities.ResultTool;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IGameService
    {
        IDataResult<List<Game>> GetAll();
        IDataResult<Game> GetById(int id);
        IResult Add(Game game);
        IResult Update(Game game);
        IResult Delete(int gameId);



        IDataResult<List<GameDto>> GetAllDto();
    }
}
