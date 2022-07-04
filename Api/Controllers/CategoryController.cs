using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly CategoryService _service;

    public CategoryController(ILogger<CategoryController> logger)
    {
        _logger = logger;
        _service = new CategoryService();
    }

    [HttpGet(Name = "ListCategories")]
    public async Task<IEnumerable<Category>> Get()
    {
        try
        {
            return await _service.ListCategories();
        }
        catch (Exception exc)
        {
            _logger.Log(LogLevel.Error, exc.GetExceptionMessages());
            return null;
        }
    }

    [HttpPost(Name = "AddCategory")]
    public async Task Post(Category category)
    {
        try
        {
            await _service.AddCategory(category);
        }
        catch (Exception exc)
        {
            _logger.Log(LogLevel.Error, exc.GetExceptionMessages());
        }
    }

    [HttpPut(Name = "UpdateCategory")]
    public async Task Put(int categoryId, Category category)
    {
        try
        {
            await _service.UpdateCategory(categoryId, category);
        }
        catch (Exception exc)
        {
            _logger.Log(LogLevel.Error, exc.GetExceptionMessages());
        }
    }

    [HttpDelete(Name = "DeleteCategory")]
    public async Task Delete(int categoryId)
    {
        try
        {
            await _service.DeleteCategory(categoryId);
        }
        catch (Exception exc)
        {
            _logger.Log(LogLevel.Error, exc.GetExceptionMessages());
        }
    }
}