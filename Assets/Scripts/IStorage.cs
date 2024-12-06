public interface IStorage 
{
    Item[] Items { get; set; }
    bool AddItem(Item item);
}
