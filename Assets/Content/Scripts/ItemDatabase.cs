using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item System/ItemDatabase", fileName = "ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<GameObject> entries = new List<GameObject>();

    public GameObject GetPrefab(string itemName)
    {
        foreach (var entry in entries)
        {
            if (entry.transform.name == itemName)
            {
                return entry;
            }
        }
        return null;
    }

    public Type GetItemType(string itemName)
    {
        foreach (var entry in entries)
        {
            if (entry.transform.name == itemName)
            {
                return Type.GetType(entry.transform.name);
            }
        }
        return null;
    }
}
