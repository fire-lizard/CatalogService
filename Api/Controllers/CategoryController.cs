using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "ListCategories")]
    public IEnumerable<Category> Get()
    {
        throw new NotImplementedException();
    }

    [HttpPost(Name = "AddCategory")]
    public IEnumerable<Category> Post()
    {
        throw new NotImplementedException();
    }

    [HttpPut(Name = "UpdateCategory")]
    public IEnumerable<Category> Put()
    {
        throw new NotImplementedException();
    }

    [HttpDelete(Name = "DeleteCategory")]
    public IEnumerable<Category> Delete()
    {
        throw new NotImplementedException();
    }
}