using Core.Utilities.ResultTool;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGameImageService
    {
        IDataResult<List<GameImage>> GetAll();
        IDataResult<GameImage> GetById(int gameImageId);
        IResult Add(GameImage gameImage);
        IResult AddList(List<GameImage> gameImages);
        IResult Delete(int gameImageId);
        IResult DeleteByGameId(int gameId);
    }
}
