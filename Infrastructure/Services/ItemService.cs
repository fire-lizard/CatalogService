using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ItemService
{
    public async Task<IEnumerable<Item>> ListItems()
    {
        await using var dbContext = new CatalogDbContext();
        return await dbContext.Items.ToListAsync();
    }

    public async Task AddItem(Item item)
    {
        await using var dbContext = new CatalogDbContext();
        await dbContext.Items.AddAsync(item);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateItem(int itemId, Item item)
    {
        await using var dbContext = new CatalogDbContext();
        var oldItem = await dbContext.Items.FindAsync((long)itemId);
        if (oldItem == null)
        {
            throw new Exception("Invalid Item ID provided!");
        }

        oldItem.CategoryId = item.CategoryId;
        oldItem.ItemAmt = item.ItemAmt;
        oldItem.ItemDesc = item.ItemDesc;
        oldItem.ItemImg = item.ItemImg;
        oldItem.ItemNm = item.ItemNm;
        oldItem.ItemPrice = item.ItemPrice;
        dbContext.Items.Update(oldItem);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteItem(int itemId)
    {
        await using var dbContext = new CatalogDbContext();
        var item = await dbContext.Items.FindAsync((long)itemId);
        if (item == null)
        {
            throw new Exception("Invalid Item ID provided!");
        }
        dbContext.Items.Remove(item);
        await dbContext.SaveChangesAsync();
    }
}