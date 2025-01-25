public class Tree : Structure, IHitable
{
    public void TakeHit()
    {
    }

    public void TakeHit(float damageValue)
    {
        TakeDamage(damageValue);
    }
}