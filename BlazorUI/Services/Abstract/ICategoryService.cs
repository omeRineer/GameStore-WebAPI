using BlazorUI.Models;
using BlazorUI.Models.ResponseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorUI.Services.Abstract
{
    public interface ICategoryService
    {
        Task<DataResponseModel<List<CategoryViewModel>>> GetAll();
    }
}
