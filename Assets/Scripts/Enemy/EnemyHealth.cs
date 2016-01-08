using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    private int currentHealth;

    ParticleSystem hitParticles;
    Transform lookAtTarget;

    void Awake ()
    {
        hitParticles = GetComponentInChildren <ParticleSystem> ();

        currentHealth = startingHealth;
        lookAtTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.transform.LookAt(lookAtTarget);

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