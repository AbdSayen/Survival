using UnityEngine;

public abstract class Particle
{
    public abstract string Name { get; }
    public static void Play(Particle particle, Vector3 position)
    {
        Object.Instantiate(
            ParticlesDatabaseManager.db.GetPrefab(particle.Name), 
            new Vector3(position.x, position.y - 0.5f, -5f), 
            Quaternion.identity);
    }
}
