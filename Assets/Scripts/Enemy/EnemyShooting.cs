using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {
    EnemyMovement enemyMovement;
    Transform player;
    PlayerHealth playerHealth;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.02f;

    float timeBetweenShots = 1.5f;
    float damage = 11f;
    float range = 40f;
    float shootAngle = 60f;
    float miss = 1f;

    Vector3 playersPreviousPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
        enemyMovement = transform.parent.gameObject.GetComponent<EnemyMovement>();

        shootableMask = LayerMask.GetMask("Environment") | LayerMask.GetMask("Player");

        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();

        playersPreviousPosition = player.position;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenShots && enemyMovement.SawPlayer)
        {
            Shoot();
        }

        if (timer >= effectsDisplayTime)
        {
            DisableEffects();
        }

        playersPreviousPosition = player.position;
    }

    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot()
    {
        timer = 0f;

        gunAudio.Stop();
        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        Vector3 vecToPlayer = player.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, vecToPlayer);
        // ce je znotraj kota strelnega polja
        if (Mathf.Abs(angleToPlayer) <= shootAngle / 2f)
        {
            shootRay.origin = transform.position;
            Vector3 playerDirection = player.position - playersPreviousPosition;
            playerDirection.z = 0;
            shootRay.direction = vecToPlayer + playerDirection 
                +  new Vector3(Random.Range(-miss, miss), Random.Range(-miss, miss), 0f);

            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                if (shootHit.collider.CompareTag("Player"))
                {
                    playerHealth.TakeDamage(damage);
                }

                gunLine.SetPosition(1, shootHit.point);
            }
            else
            {
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
        }
    }

}
