public interface IStorage 
{
    Item[] Items { get; set; }

    public int GetItemsCount()
    {
        int count = 0;

        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] != null)
            {
                count++;
            }
        }
        return count;
    }

    public int GetFirstFilledSlotId()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] != null)
            {
                return i;
            }
        }
        return -1;
    }

    public int GetFirstEmptySlotId()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

    public bool AddItem(Item item)
    {
        int firstEmptySlot = GetFirstEmptySlotId();
        if (firstEmptySlot != -1)
        {
            Items[firstEmptySlot] = item;
            InventoryUI.Instance.Render(Items);
            return true;
        }
        return false;
    }
}
