using BlazorDemo.Client.Services.Interfaces;
using BlazorDemo.Client.Utility;
using BlazorDemo.Shared.Utility;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace BlazorDemo.Client.Services;

public class ApiService : IApiService
{
    private const string contentTypeProblem = "application/problem+json";

    private readonly HttpClient http;
    private readonly IJSRuntime jSRuntime;

    public ApiService(HttpClient http, IJSRuntime jSRuntime)
    {
        this.http = http;
        this.jSRuntime = jSRuntime;
    }

    public Task<bool> GetAsync(string url, bool handleError = true, CancellationToken cancellationToken = default)
        => RequestAsync(client => client.GetAsync(url, cancellationToken), handleError, cancellationToken);

    public Task<ApiResult<TResponseData>> GetAsync<TResponseData>(string url, bool handleError = true, CancellationToken cancellationToken = default)
        => RequestWithResultAsync<TResponseData>(client => client.GetAsync(url, cancellationToken), handleError, cancellationToken);

    public Task<bool> PostAsync<TRequestData>(string url, TRequestData requestData, bool handleError = true, CancellationToken cancellationToken = default)
        => RequestAsync(client => client.PostAsJsonAsync(url, requestData, cancellationToken), handleError, cancellationToken);

    public Task<ApiResult<TRequestData>> PostWithResultAsync<TRequestData>(string url, TRequestData requestData, bool handleError = true, CancellationToken cancellationToken = default)
        => PostWithResultAsync<TRequestData, TRequestData>(url, requestData, handleError, cancellationToken);

    public Task<ApiResult<TResponseData>> PostWithResultAsync<TRequestData, TResponseData>(string url, TRequestData requestData, bool handleError = true, CancellationToken cancellationToken = default)
        => RequestWithResultAsync<TResponseData>(client => client.PostAsJsonAsync(url, requestData, cancellationToken), handleError, cancellationToken);

    public Task<bool> DeleteAsync(string url, bool handleError = true, CancellationToken cancellationToken = default)
        => RequestAsync(client => client.DeleteAsync(url, cancellationToken), handleError, cancellationToken);

    private async Task<bool> RequestAsync(Func<HttpClient, Task<HttpResponseMessage>> requestDelegate, bool handleError, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await SendRequestAsync(requestDelegate, handleError, cancellationToken);
        return response.IsSuccessStatusCode;
    }

    private async Task<ApiResult<TResponseData>> RequestWithResultAsync<TResponseData>(Func<HttpClient, Task<HttpResponseMessage>> requestDelegate, bool handleError, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await SendRequestAsync(requestDelegate, handleError, cancellationToken);

        if (!response.IsSuccessStatusCode) {
            return new ApiResult<TResponseData>();
        }

        if (typeof(TResponseData).Is<string>()) {
            string result = await response.Content.ReadAsStringAsync(cancellationToken);
            return new ApiResult<TResponseData>((TResponseData)(object)result);
        }

        TResponseData? data = await response.Content.ReadFromJsonAsync<TResponseData>(cancellationToken);
        return new ApiResult<TResponseData>(data);
    }

    private async Task<HttpResponseMessage> SendRequestAsync(Func<HttpClient, Task<HttpResponseMessage>> requestDelegate, bool handleError, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await requestDelegate(http);

        if (handleError && !response.IsSuccessStatusCode) {
            await HandleResponseErrorAsync(response, cancellationToken);
        }

        return response;
    }

    private async Task HandleResponseErrorAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        if (response.Content.Headers.ContentType?.MediaType?.Contains(contentTypeProblem) is true) {
            ProblemDetails details = (await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken))!;
            await jSRuntime.AlertAsync($"Error {details.Status}: {details.Title}  {details.Detail}");
        }
        else {
            await jSRuntime.AlertAsync($"Error {(int)response.StatusCode}: {response.ReasonPhrase}");
        }
    }
}
