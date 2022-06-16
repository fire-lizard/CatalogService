using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;

    public ItemController(ILogger<ItemController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "ListCategories")]
    public IEnumerable<Item> Get()
    {
        throw new NotImplementedException();
    }

    [HttpPost(Name = "AddItem")]
    public IEnumerable<Item> Post()
    {
        throw new NotImplementedException();
    }

    [HttpPut(Name = "UpdateItem")]
    public IEnumerable<Item> Put()
    {
        throw new NotImplementedException();
    }

    [HttpDelete(Name = "DeleteItem")]
    public IEnumerable<Item> Delete()
    {
        throw new NotImplementedException();
    }
}