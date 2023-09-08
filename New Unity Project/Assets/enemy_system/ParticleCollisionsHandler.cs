using UnityEngine;

public class ParticleCollisionsHandler : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // This function is called when a particle collides with the GameObject that has this script.
    private void OnParticleCollision(GameObject other)
    {
        // Check if the collision occurred with a specific tag or layer.
        if (other.CompareTag("Cleaner"))
        {
            //Debug.Log("Particle collided with the player.");
            // Add your custom logic here for when a particle collides with the player.

            // Get all particles currently in the system.
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
            int numParticles = particleSystem.GetParticles(particles);

            // Loop through all particles and deactivate them.
            for (int i = 0; i < numParticles; i++)
            {
                if (IsParticleCollidingWithObject(particles[i], other))
                {
                    // Deactivate the specific particle by setting its remainingLifetime to 0.
                    //particles[i].remainingLifetime = 0f;
                }
            }

            // Apply the modified particles back to the system.
            //particleSystem.SetParticles(particles, numParticles);

            //Debug.Log("Particle wadasr4ewtr45y4ytrt.");
        }

    }

    // Check if a particle is colliding with a specified GameObject.
    private bool IsParticleCollidingWithObject(ParticleSystem.Particle particle, GameObject obj)
    {
        Collider objCollider = obj.GetComponent<Collider>();
        if (objCollider != null)
        {
            Vector3 particlePosition = particleSystem.transform.TransformPoint(particle.position);
            if (objCollider.bounds.Contains(particlePosition))
            {
                return true;
            }
        }
        return false;
    }
}