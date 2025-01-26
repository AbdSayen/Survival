using UnityEngine;

public class ParticlesDatabaseManager : MonoBehaviour
{
    [SerializeField] private Database database;
    public static Database db;

    private void Awake()
    {
        db = database;
    }
}