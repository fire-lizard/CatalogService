using Domain.Common;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;
    private readonly ItemService _service;

    public ItemController(ILogger<ItemController> logger)
    {
        _logger = logger;
        _service = new ItemService();
    }

    [HttpGet(Name = "ListItems")]
    public async Task<IEnumerable<Item>> Get()
    {
        try
        {
            return await _service.ListItems();
        }
        catch (Exception exc)
        {
            _logger.Log(LogLevel.Error, exc.GetExceptionMessages());
            return null;
        }
    }

    [HttpPost(Name = "AddItem")]
    public async Task Post(Item item)
    {
        try
        {
            await _service.AddItem(item);
        }
        catch (Exception exc)
        {
            _logger.Log(LogLevel.Error, exc.GetExceptionMessages());
        }
    }

    [HttpPut(Name = "UpdateItem")]
    public async Task Put(Item item, int itemId)
    {
        try
        {
            await _service.UpdateItem(itemId, item);
        }
        catch (Exception exc)
        {
            _logger.Log(LogLevel.Error, exc.GetExceptionMessages());
        }
    }

    [HttpDelete(Name = "DeleteItem")]
    public async Task Delete(int itemId)
    {
        try
        {
            await _service.DeleteItem(itemId);
        }
        catch (Exception exc)
        {
            _logger.Log(LogLevel.Error, exc.GetExceptionMessages());
        }
    }
}