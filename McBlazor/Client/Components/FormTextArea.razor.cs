using Microsoft.AspNetCore.Components;

namespace McBlazor.Client.Components;

public partial class FormTextArea : ComponentBase
{
    [Parameter]
    public int Rows { get; set; }
}
