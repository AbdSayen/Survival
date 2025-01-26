using UnityEngine;

public class Rock : Structure, IHitable
{
    public Item[] Items { get; set; }
    private float dropItemChance = 0.3f;

    public void TakeHit()
    {
        if (Random.Range(0, 100) <= dropItemChance * 100)
        {
            ItemWorld.Drop(new Stone(), transform.position);
        }
        Particle.Play(new Dust(), transform.position);
    }

    public void TakeHit(float damageValue)
    {
        TakeHit();
        TakeDamage(damageValue);
    }
}