using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Entity : MonoBehaviour, IHitable
{
    [Header("Base")]
    [SerializeField] private Tilemap walkable;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Transform[] moveTargets;

    [Header("Health & Damage")]
    [SerializeField] protected float maxHealth;
    private float health;

    private Animator animator;
    private const string IS_WALKING = "IS_WALKING";

    IEnumerator moving;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        health = maxHealth;
    }

    public virtual void TakeHit()
    {
        // Инициировать панику (позже)
    }

    public void TakeHit(float damageValue)
    {
        TakeDamage(damageValue);
    }

    protected virtual void TakeDamage(float damageValue)
    {
        TakeHit();
        health -= damageValue;
        if (health <= 0) Die();
    }

    protected virtual void Die() { Destroy(gameObject); }

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
