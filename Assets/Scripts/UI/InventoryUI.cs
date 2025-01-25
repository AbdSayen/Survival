using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;
    public Image[] slots;

    public int selectedSlotId = 1;

    private void Awake()
    {
        Instance = this;
        RenderSelectedSlot();
    }

    private void Update()
    {
        Handler();
    }

    public void Handler()
    {
        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                selectedSlotId = i - 1;
                RenderSelectedSlot();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            selectedSlotId = 9;
            RenderSelectedSlot();
        }
    }

    private void RenderSelectedSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (selectedSlotId == i)
            {
                Color currentColor = slots[i].color;
                slots[i].color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
            }
            else
            {
                Color currentColor = slots[i].color;
                slots[i].color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.50f);
            }
        }
    }

    public void Render(Item[] items)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (items[i] == null) 
            {
                slots[i].gameObject.SetActive(false);
                continue;
            } 
            
            slots[i].gameObject.SetActive(true);
            slots[i].sprite = ItemDatabaseManager.db
                .GetPrefab(items[i].Name)   
                .GetComponent<SpriteRenderer>().sprite;
        }

        RenderSelectedSlot();
    }

    public void Render(List<Item> items) => Render(items.ToArray());
}