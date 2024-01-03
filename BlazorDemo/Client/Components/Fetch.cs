using BlazorDemo.Client.Services.Interfaces;
using BlazorDemo.Client.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorDemo.Client.Components;

public class Fetch<T> : ComponentBase
{
    private bool _isInitialized;
    private bool _hasError;
    private T? _data;

    [Parameter, EditorRequired]
    public string Url { get; set; } = default!;

    [Parameter]
    public RenderFragment? ErrorContent { get; set; }

    [Parameter, EditorRequired]
    public RenderFragment<T?>? SuccessContent { get; set; } = default!;

    [Parameter]
    public EventCallback<T?> OnSuccess { get; set; }

    [Parameter]
    public bool AlertErrors { get; set; }

    [Inject]
    public IApiService Api { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        ApiResult<T> result = await Api.GetAsync<T>(Url, AlertErrors);

        if (result.Success) {
            await OnSuccess.InvokeAsync(result.Value);
        }

        _hasError = !result.Success;
        _data = result.Value;
        _isInitialized = true;
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (!_isInitialized) {
            return;
        }

        if (_hasError) {
            builder.AddContent(0, ErrorContent);
        } else {
            builder.AddContent(1, SuccessContent, _data);
        }
    }
}
