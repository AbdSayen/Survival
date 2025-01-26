using System;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public Item item;
    [SerializeField] private string itemName;

    private Vector3 startPosition;
    public float amplitude = 1f;
    public float frequency = 3f;

    private void Start()
    {
        startPosition = transform.position;
        item = (Item)Activator.CreateInstance(ItemDatabaseManager.db.GetItemType(itemName));
    }

    public static GameObject Spawn(string itemType, Vector3 position)
    {
        return Instantiate(ItemDatabaseManager.db.GetPrefab(itemType), position, Quaternion.identity);
    }

    public static void Drop(Item item, Vector3 position)
    {
        Vector3 targetPosition = position + new Vector3(
            UnityEngine.Random.Range(-0.5f, 0.5f),
            UnityEngine.Random.Range(-0.5f, 0.5f),
            0f
        );

        ItemMover.Move(Spawn(item.Name, position), targetPosition, 0.25f);
    }
    private void Update()
    {
        //Animate();
    }

    private void Animate()
    {
        float offsetY = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = new Vector3(startPosition.x, startPosition.y + offsetY, startPosition.z);
    }
}
