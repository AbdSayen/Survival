using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float maxAttackDistance = 1f; 
    [SerializeField] private LayerMask hitLayerMask; 

    private Vector3 attackStart;
    private Vector3 attackEnd;

    public void Handler()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Attack();
        }
    }

    private void Attack()
    {
        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, maxAttackDistance, hitLayerMask);

        foreach (var hit in hits)
        {
            IHitable hitable = hit.collider.GetComponent<IHitable>();
            if (hitable != null)
            {
                hitable.TakeHit(damage);
            }
        }

        if (hits.Length > 0)
        {
            attackStart = transform.position;
            attackEnd = hits[hits.Length - 1].point;
        }
        else
        {
            attackStart = transform.position;
            attackEnd = (Vector2)transform.position + direction * maxAttackDistance;
        }
    }
}