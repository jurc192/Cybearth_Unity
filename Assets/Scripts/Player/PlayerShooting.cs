using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] WeaponInventory weaponInventory;
    [SerializeField] AudioClip gunShot;
    [SerializeField] AudioClip dryFire;
    [SerializeField] AudioClip reloadGun;

    Weapon weapon;
    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.02f;

    Image crosshairImage;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Environment") | LayerMask.GetMask("Enemies");

        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();

        crosshairImage = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image>();

        weapon = weaponInventory.CurrentWeapon;

    }

    void Update()
    {
        weapon = weaponInventory.CurrentWeapon;

        changeCrosshairColor();

        timer += Time.deltaTime;


        if (((Input.GetButton("Fire1") && weapon.IsAutomatic) || (Input.GetButtonDown("Fire1") && !weapon.IsAutomatic))
                && timer >= weapon.TimeBetweenBullets && Time.timeScale != 0)
        {
            if (weapon.CanShoot) Shoot();
            else if(!weapon.IsReloading)
            {
                gunAudio.clip = dryFire;
                gunAudio.Stop();
                gunAudio.Play();
            }
        }


        if (timer >= effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot()
    {
        weapon.shootBullet();

        timer = 0f;

        gunAudio.clip = gunShot;
        gunAudio.Stop();
        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = Camera.main.transform.position;
        shootRay.direction = Camera.main.transform.forward;
        //shootRay.origin = transform.position;
        //shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, weapon.Range, shootableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            // If the EnemyHealth component exist...
            if (enemyHealth != null)
            {
                //... the enemy should take damage.
                enemyHealth.TakeDamage(weapon.DamagePerShot, shootHit.point, shootRay.origin);
            }

            // Set the second position of the line renderer to the point the raycast hit.
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * weapon.Range);
        }
    }

    void changeCrosshairColor()
    {
        crosshairImage.color = Color.black;

        shootRay.origin = Camera.main.transform.position;
        shootRay.direction = Camera.main.transform.forward;
        if (Physics.Raycast(shootRay, out shootHit, weapon.Range, shootableMask))
        {
            if (shootHit.transform.CompareTag("Enemy"))
            {
                crosshairImage.color = Color.red;
            }
        }
    }

    public void PlayReload()
    {
        gunAudio.clip = reloadGun;
        gunAudio.Stop();
        gunAudio.Play();
    }
}