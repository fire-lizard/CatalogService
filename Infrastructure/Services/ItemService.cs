using Domain.Entities;

namespace Infrastructure.Services;

public class ItemService
{
    public IEnumerable<Item> ListItems()
    {
        throw new NotImplementedException();
    }
    public Item GetItem(int itemId)
    {
        throw new NotImplementedException();
    }
    public void AddItem(Item item){}
    public void UpdateItem(int itemId, Item item){}
    public void DeleteItem(int itemId){}
}