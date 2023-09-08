using UnityEditor.UIElements;
using UnityEngine;

public class TrashCollector : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem particleSystem;
    private ParticleSystem.Particle[] particles;
    private Vector3[] particleRots;

    private float cleanerToTrashDistance = 15F;

    private Vector3 zeroPointPosition = new Vector3(0,0,0);

    [SerializeField]
    private GameObject cleaner;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
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

        int particleCount = particleSystem.GetParticles(particles);

        // Loop through the particles and adjust rotation based on velocity magnitude.
        for (int i = 0; i < particleCount; i++)
        {
            Vector3 velocity = particles[i].velocity;

            Vector2 partPos = new Vector2(particles[i].position.x, particles[i].position.y);
            float distance = Vector2.Distance(partPos, new Vector2(cleaner.transform.position.x, cleaner.transform.position.y));

            if (distance < cleanerToTrashDistance)
            {
                particles[i].remainingLifetime = 0;
                particles[i].position = zeroPointPosition;
            }
            else
            //if (distance < 40F)
            //{
                //Debug.Log("Particle wadasr4e: " + distance);
            //}

//Code for stopping Rotation
            

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


        // Apply the modified particles back to the system.
        particleSystem.SetParticles(particles, particleCount);
    }

}
