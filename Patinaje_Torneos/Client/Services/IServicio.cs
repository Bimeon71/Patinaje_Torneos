namespace Patinaje_Torneos.Client.Services
{
    public interface IServicio
    {
        Task<List<T>> GetList<T>(string url);
        Task<HttpResponseWrapper<T>> GetHttp<T>(string url);
        Task<T> Get<T>(string url);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
        Task Put<T>(string url, T enviar);
        Task Delete(string url);
    }
}
