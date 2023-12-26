using BlazorDemo.Client.Components;
using BlazorDemo.Shared.Components;
using BlazorDemo.Shared.Models.Todo.ViewModels;
using BlazorDemo.Shared.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDemo.Server.Controllers;

[ApiController, Route("[controller]")]
public class TodoController : ControllerBase
{
    [HttpGet("GetOk")]
    public IActionResult GetOk() => Ok(new TodoItemViewModel());

    [HttpGet("Get")]
    public TodoItemViewModel Get() => new();

    [HttpGet("GetString")]
    public string GetString() => "Hello";

    [HttpGet("Problem")]
    public IActionResult GetProblem() => Problem("Oh no.");

    [HttpGet("ThrowException")]
    public IActionResult ThrowException() => throw new NotImplementedException("Nothing to see here...");

    [HttpGet("GetItems")]
    public IEnumerable<SelectItem<string>> GetItems() 
        => FormHelpers.CreateSelectItems("Foo", "Bar", "Baz");
}
