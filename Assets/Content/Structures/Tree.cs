using UnityEngine;

public class Tree : Structure, IHitable
{
    public Item[] Items { get; set; }
    private float dropItemChance = 0.5f;

    public void TakeHit()
    {
        if (Random.Range(0, 100) <= dropItemChance * 100)
        {
            ItemWorld.Drop(new Wood(), transform.position);
        }
        Particle.Play(new Dust(), transform.position);
    }

    public void TakeHit(float damageValue)
    {
        TakeHit();
        TakeDamage(damageValue);
    }
}