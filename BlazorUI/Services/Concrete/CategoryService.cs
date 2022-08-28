using BlazorUI.Models;
using BlazorUI.Models.ResponseModel;
using BlazorUI.Services.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorUI.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpclient;

        public CategoryService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task<DataResponseModel<List<CategoryViewModel>>> GetAll()
        {
            return await _httpclient.GetFromJsonAsync<DataResponseModel<List<CategoryViewModel>>>($"https://localhost:44354/api/categories");
        }
    }
}
