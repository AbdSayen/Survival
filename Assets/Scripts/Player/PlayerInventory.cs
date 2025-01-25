using UnityEngine;

public class PlayerInventory : MonoBehaviour, IStorage
{
    public Item[] Items { get; set; }

    private int inventorySize = 10;
    private float detectionRadius = 1f;

    private void Start()
    {
        Items = new Item[inventorySize];
    }

    public void CheckForItem()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (Collider2D collider in colliders)
        {
            ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
            if (itemWorld != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (AddItem(itemWorld.item))
                    {
                        Destroy(itemWorld.gameObject);
                    }
                }
            }
        }
    }

    public void Handler()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }
    }

    public void DropItem()
    {
        if (GetItemsCount() > 0)
        {
            int itemId = InventoryUI.Instance.selectedSlotId;
            if (Items[itemId] == null) return;

            Instantiate(ItemDatabaseManager.db.GetPrefab(Items[itemId].Name), transform.position, Quaternion.identity);
            Items[itemId] = null;
            InventoryUI.Instance.selectedSlotId = GetFirstFilledSlotId();
            InventoryUI.Instance.Render(Items);
        }
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

    private int GetItemsCount()
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

    private int GetFirstFilledSlotId()
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

    private int GetFirstEmptySlotId()
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
}