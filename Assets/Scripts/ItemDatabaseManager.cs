using UnityEngine;

public class ItemDatabaseManager : MonoBehaviour
{
    [SerializeField] private ItemDatabase database;
    public static ItemDatabase db;

    private void Awake()
    {
        db = database;
    }
}