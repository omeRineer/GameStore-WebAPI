using BlazorUI.Models;
using BlazorUI.Models.ResponseModel;
using BlazorUI.Services.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorUI.Services.Concrete
{
    public class GameService : IGameService
    {
        public readonly HttpClient _httpClient;

        public GameService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DataResponseModel<List<GameViewModel>>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<DataResponseModel<List<GameViewModel>>>($"https://localhost:44354/api/games");
        }

        public async Task<DataResponseModel<GameViewModel>> GetById(int gameId)
        {
            return await _httpClient.GetFromJsonAsync<DataResponseModel<GameViewModel>>($"https://localhost:44354/api/games/{gameId}");
        }
    }
}
