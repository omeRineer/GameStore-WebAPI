namespace BlazorUI.Models.ResponseModel
{
    public class DataResponseModel<T>:ResponseModel
    {
        public T Data { get; set; }
    }
}
