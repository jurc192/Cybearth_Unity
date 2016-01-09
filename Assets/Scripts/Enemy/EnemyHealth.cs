using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    private int currentHealth;

    ParticleSystem hitParticles;
    Transform lookAtTarget;
    EnemyMovement enemyMovement;

    void Awake ()
    {
        enemyMovement = gameObject.GetComponent<EnemyMovement>();

        hitParticles = GetComponentInChildren <ParticleSystem> ();

        currentHealth = startingHealth;
        lookAtTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage (int amount, Vector3 hitPoint, Vector3 origin)
    {
        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.transform.LookAt(lookAtTarget);

        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }

        if (!enemyMovement.SawPlayer)
        {
            enemyMovement.SetNavDestination(origin);
        }
    }

    void Death ()
    {
        EnemyDrop.GetLucky(transform.position);
        Destroy(gameObject);
    }
}