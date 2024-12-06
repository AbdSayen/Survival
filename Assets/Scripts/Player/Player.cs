using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInventory))]
public class Player : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerInventory inventory;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        inventory = GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        movement.SetDirection();
        inventory.CheckForItem();
        inventory.Handler();
    }

    private void FixedUpdate()
    {
        movement.Move();
    }
}