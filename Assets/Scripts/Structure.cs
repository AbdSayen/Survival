using UnityEngine;

public abstract class Structure : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float health;

    protected virtual void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageValue)
    {
        health -= damageValue;

        if (health <= 0)
            Collapse();
        else
            if (this is IHitable) ((IHitable)this).TakeHit();
    }

    protected virtual void Collapse()
    {
        Destroy(gameObject);
    }
}
