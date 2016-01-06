using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;

    ParticleSystem hitParticles;

    void Awake ()
    {
        hitParticles = GetComponentInChildren <ParticleSystem> ();

        currentHealth = startingHealth;
    }

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;

        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        EnemyDrop.GetLucky(transform.position);
        Destroy(gameObject);
    }
}