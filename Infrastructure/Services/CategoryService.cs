using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CategoryService
{
    public async Task<IEnumerable<Category>> ListCategories()
    {
        await using var dbContext = new CatalogDbContext();
        return await dbContext.Categories.ToListAsync();
    }

    public async Task AddCategory(Category category)
    {
        await using var dbContext = new CatalogDbContext();
        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateCategory(int categoryId, Category category)
    {
        await using var dbContext = new CatalogDbContext();
        var oldCategory = await dbContext.Categories.FindAsync((long)categoryId);
        if (oldCategory == null)
        {
            throw new Exception("Category ID not found!");
        }

        oldCategory.CategoryImg = category.CategoryImg;
        oldCategory.CategoryNm = category.CategoryNm;
        oldCategory.ParentCategoryId = category.ParentCategoryId;
        dbContext.Categories.Update(oldCategory);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteCategory(int categoryId)
    {
        await using var dbContext = new CatalogDbContext();
        var category = await dbContext.Categories.FindAsync((long)categoryId);
        if (category == null)
        {
            throw new Exception("Category ID not found!");
        }

        var itemsToRemove = dbContext.Items.Where(t => t.CategoryId == categoryId);
        dbContext.Items.RemoveRange(itemsToRemove);
        dbContext.Categories.Remove(category);
        await dbContext.SaveChangesAsync();
    }
}