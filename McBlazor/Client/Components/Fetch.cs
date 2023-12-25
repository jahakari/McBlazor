using McBlazor.Client.Services.Interfaces;
using McBlazor.Client.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace McBlazor.Client.Components;

public class Fetch<T> : ComponentBase
{
    private bool isInitialized;
    private bool hasError;
    private T? data;

    [Parameter, EditorRequired]
    public string Url { get; set; } = default!;

    [Parameter]
    public RenderFragment? ErrorContent { get; set; }

    [Parameter, EditorRequired]
    public RenderFragment<T?>? SuccessContent { get; set; } = default!;

    [Inject]
    public IApiService Api { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        ApiResult<T> result = await Api.GetAsync<T>(Url);

        hasError = !result.Success;
        data = result.Value;
        isInitialized = true;
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (!isInitialized) {
            return;
        }

        if (hasError) {
            builder.AddContent(0, ErrorContent);
        } else {
            builder.AddContent(1, SuccessContent, data);
        }
    }
}
