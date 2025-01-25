using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInventory))]
[RequireComponent(typeof(PlayerAttack))]
public class Player : MonoBehaviour
{
    public Player instance;

    private PlayerMovement movement;
    private PlayerInventory inventory;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        inventory = GetComponent<PlayerInventory>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Start() => instance = this;

    private void Update()
    {
        movement.SetDirection();
        inventory.CheckForItem();
        inventory.Handler();
        playerAttack.Handler();
    }

    private void FixedUpdate()
    {
        movement.Move();
    }
}