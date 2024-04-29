using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Pages;

public partial class Bar : ComponentBase
{
    private int val1 = 1;
    private int val2 = 2;
    private int val3 = 3;

    private bool render = true;

    protected override bool ShouldRender() => render;

    private async Task Update()
    {
        render = false;

        for (int i = 0; i < 10; i++) {
            val1 *= 2;
            val2 *= 2;
            val3 *= 2;

            StateHasChanged();
            await Task.Delay(500);
        }

        render = true;
    }
}
