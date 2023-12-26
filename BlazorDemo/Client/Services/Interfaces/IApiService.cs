
using McBlazor.Client.Utility;

namespace McBlazor.Client.Services.Interfaces;

public interface IApiService
{
    Task<bool> DeleteAsync(string url, bool handleError = true, CancellationToken cancellationToken = default);
    Task<bool> GetAsync(string url, bool handleError = true, CancellationToken cancellationToken = default);
    Task<ApiResult<T>> GetAsync<T>(string url, bool handleError = true, CancellationToken cancellationToken = default);
    Task<bool> PostAsync<TRequestData>(string url, TRequestData requestData, bool handleError = true, CancellationToken cancellationToken = default);
    Task<ApiResult<TRequestData>> PostWithResultAsync<TRequestData>(string url, TRequestData requestData, bool handleError = true, CancellationToken cancellationToken = default);
    Task<ApiResult<TResponseData>> PostWithResultAsync<TRequestData, TResponseData>(string url, TRequestData requestData, bool handleError = true, CancellationToken cancellationToken = default);
}
