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
        item = (Item)System.Activator.CreateInstance(ItemDatabaseManager.db.GetItemType(itemName));
    }
       
    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        float offsetY = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPosition.x, startPosition.y + offsetY, startPosition.z);
    }
}
