using UnityEngine;

public class ParticleCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystem;
    private ParticleSystem.Particle[] particles;
    private Vector3[] particleRots;

    private void Start()
    {
        //particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        // Check if the particle collided with a specific collider (optional).
        if (other.CompareTag("YourTag"))
        {
            // Access the Particle System component.
            //ParticleSystem particleSystem = GetComponent<ParticleSystem>();

            // Stop the Particle System (stop emitting new particles).
            //particleSystem.Stop();

            // Optionally, you can also disable the Particle System GameObject to freeze existing particles.
            // gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Get the current particles from the Particle System.
        int maxParticles = particleSystem.main.maxParticles;
        if (particles == null || particles.Length < maxParticles)
        {
            particles = new ParticleSystem.Particle[maxParticles];
            particleRots = new Vector3[maxParticles];
        }

        //Debug.Log(" fkjdfnjdf ");

        int particleCount = particleSystem.GetParticles(particles);

        // Loop through the particles and adjust rotation based on velocity magnitude.
        for (int i = 0; i < particleCount; i++)
        {
            Vector3 velocity = particles[i].velocity;

            // Check if the particle has no velocity (near zero magnitude).
            if (velocity.magnitude < 0.01f || velocity.y > 0)
            {
                // Set the particle's rotation to zero.
                if (particleRots[i].x == 0 && particleRots[i].y == 0 && particleRots[i].z == 0)
                {
                    particleRots[i] = particles[i].rotation3D;
                }
                else
                {
                    particles[i].rotation3D = particleRots[i];
                }
            }
        }

        // Apply the modified particles back to the Particle System.
        particleSystem.SetParticles(particles, particleCount);
    }
}