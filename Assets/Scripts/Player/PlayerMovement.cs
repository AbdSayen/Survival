using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Tilemap walkableTilemap;

    private Vector2 movement;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetDirection()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetInteger("runVertical", (int)(movement.y));
        animator.SetInteger("runHorizontal", (int)(movement.x));

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
    }

    public void Move()
    {
        Vector3 newPosition = transform.position + (Vector3)(movement * moveSpeed * Time.deltaTime);
        Vector3Int tilePosition = walkableTilemap.WorldToCell(newPosition);

        if (walkableTilemap.HasTile(tilePosition)) transform.position = newPosition;
    }
}
