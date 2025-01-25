using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Entity : MonoBehaviour
{
    [SerializeField] private Tilemap walkable;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Transform[] moveTargets;

    private Animator animator;
    private const string IS_WALKING = "IS_WALKING";

    IEnumerator moving;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        StartMoving();
    }

    protected void StartMoving()
    {
        if (moving == null) moving = Moving();
        StartCoroutine(moving);
    }

    private IEnumerator Moving()
    {
        while (true)
        {
            int destinationId = Random.Range(0, moveTargets.Length);
            Vector3 targetPos = moveTargets[destinationId].position;

            if (!walkable.HasTile(walkable.WorldToCell(targetPos))) continue;

            GetComponent<SpriteRenderer>().flipX = !(targetPos.x > transform.position.x);

            animator.SetBool(IS_WALKING, true);
            while (Vector3.Distance(transform.position, targetPos) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                yield return null;
            }

            animator.SetBool(IS_WALKING, false);

            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }
}
