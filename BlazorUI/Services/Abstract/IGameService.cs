using BlazorUI.Models;
using BlazorUI.Models.ResponseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorUI.Services.Abstract
{
    public interface IGameService
    {
       Task<DataResponseModel<List<GameViewModel>>> GetAll();
       Task<DataResponseModel<GameViewModel>> GetById(int gameId);
    }
}
