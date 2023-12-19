using McBlazor.Client.Utility;
using McBlazor.Shared.Utility;
using McBlazor.Shared.Validation;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Linq.Expressions;

namespace McBlazor.Client.Components;

public abstract class FormEditorBase<T> : ValidatableComponent
{
    private readonly bool isStringValue = typeof(T).Is<string>();
    private MemberValidator memberValidator = MemberNonValidator.Instance;

    protected ElementReference editorElement;
    protected T? _value;

    [Parameter, EditorRequired]
    public T? Value { get; set; }

    [Parameter, EditorBrowsable(EditorBrowsableState.Never)]
    public Expression<Func<T?>> ValueExpression { get; set; } = null!;

    [Parameter]
    public EventCallback<T?> ValueChanged { get; set; }

    [Parameter]
    public int MyProperty { get; set; }

    [Parameter]
    public IEqualityComparer<T> EqualityComparer { get; set; } = EqualityComparer<T>.Default;

    [Parameter]
    public TypeConverter? TypeConverter { get; set; }

    protected string? _label;

    [Parameter]
    public string? Label { get; set; }

    protected string? _note;

    [Parameter]
    public string? Note { get; set; }

    protected string? _title;

    [Parameter]
    public string? Title { get; set; }

    protected string? _placeholder;

    [Parameter]
    public string? Placeholder { get; set; }

    protected string _id;

    [Parameter]
    public string? Id { get; set; }

    public override Task SetParametersAsync(ParameterView parameters)
    {
        TrySetParameterField(parameters, nameof(Label), ref _label);
        TrySetParameterField(parameters, nameof(Note), ref _note);
        TrySetParameterField(parameters, nameof(Title), ref _title);
        TrySetParameterField(parameters, nameof(Placeholder), ref _placeholder);

        return base.SetParametersAsync(parameters);
    }

    private static void TrySetParameterField<TField>(ParameterView parameters, string parameterName, ref TField? field)
    {
        if (parameters.TryGetValue(parameterName, out TField? value)) {
            field = value;
        }
    }

    protected override void OnParametersSet() => _value = Value;

    protected override void OnInitialized()
    {
        var provider = MemberMetadataProvider.Create(ValueExpression);
        memberValidator = MemberValidator.Create(provider);

        _label ??= provider.Label;
        _note ??= provider.Note;
        _title ??= provider.Title;
        _placeholder ??= provider.Placeholder;

        _id = Id ?? "_" + Guid.NewGuid();

        base.OnInitialized();
    }

    protected Task SetValueAsync(T? value)
    {
        if (EqualityComparer.Equals(_value, value)) {
            return Task.CompletedTask;
        }

        _value = value;
        return ValueChanged.InvokeAsync(value);
    }

    protected Task EditorChangedAsync(ChangeEventArgs e)
    {
        if (TryGetValue(e.Value, out T? result)) {
            return SetValueAsync(result);
        }

        return ResetToCurrentValueAsync();
    }

    protected async Task ResetToCurrentValueAsync()
    {
        T? value = _value;

        await SetValueAsync(default);
        await Task.Delay(1);
        await SetValueAsync(value);
    }

    protected override Task<string?> ValidateInternalAsync() => memberValidator.ValidateAsync(_value);

    protected ValueTask FocusAsync() => editorElement.FocusAsync();

    private bool TryGetValue(object? value, out T? result)
    {
        try {
            result = value switch
            {
                null => default,
                string s when !isStringValue && string.IsNullOrWhiteSpace(s) => default,
                _ when TypeConverter is not null => (T?)TypeConverter.ConvertFrom(value),
                _ => EditorHelpers.ConvertFrom<T>(value)
            };

            return true;
        }
        catch (Exception) {
            result = default;
            return false;
        }
    }
}
