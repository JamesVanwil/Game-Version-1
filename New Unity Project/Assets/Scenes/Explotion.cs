using UnityEngine;

public class Explotion : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(" fkjdfnjdfudfihuuhdfdfu");
        // Check if the particle collided with a specific collider (optional).
        //if (other.CompareTag("YourTag"))
        {
            // Access the Particle System component.
           // ParticleSystem particleSystem = GetComponent<ParticleSystem>();

            // Stop the Particle System (stop emitting new particles).
            //particleSystem.Stop();

            // Optionally, you can also disable the Particle System GameObject to freeze existing particles.
            // gameObject.SetActive(false);
        }
    }
}
