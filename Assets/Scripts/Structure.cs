using System.Collections;
using UnityEngine;

public abstract class Structure : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    private float health;

    protected virtual void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageValue)
    {
        health -= damageValue;

        if (this is IHitable) ((IHitable)this).TakeHit();

        if (health <= 0) Collapse();
        else if (this is IHitable) 
        {
            TakeDamageAnimation();
        }
    }

    private void TakeDamageAnimation()
    {
        StartCoroutine(AnimateDamage());

        IEnumerator AnimateDamage()
        {
            Vector3 originalScale = transform.localScale;
            Vector3 damagedScale = originalScale * 0.9f;

            float duration = 0.1f;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                transform.localScale = Vector3.Lerp(originalScale, damagedScale, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.localScale = damagedScale;

            elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                transform.localScale = Vector3.Lerp(damagedScale, originalScale, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.localScale = originalScale;
        }
    }

    protected virtual void Collapse()
    {
        Destroy(gameObject);
    }
}
