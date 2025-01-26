using UnityEngine;

public class ItemDatabaseManager : MonoBehaviour
{
    [SerializeField] private Database database;
    public static Database db;

    private void Awake()
    {
        db = database;
    }
}