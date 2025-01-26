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
                    if (((IStorage)this).AddItem(itemWorld.item))
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
        if (((IStorage)this).GetItemsCount() > 0)
        {
            int itemId = InventoryUI.Instance.selectedSlotId;
            if (Items[itemId] == null) return;

            ItemWorld.Spawn(Items[itemId].Name, transform.position);
            Items[itemId] = null;
            InventoryUI.Instance.selectedSlotId = ((IStorage)this).GetFirstFilledSlotId();
            InventoryUI.Instance.Render(Items);
        }
    }
}