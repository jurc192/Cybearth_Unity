using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
    [SerializeField] bool isAutomatic;
    [SerializeField] int maxBullets;
    [SerializeField] int currentNumberOfBullets;
    [SerializeField] int clipSize;
    [SerializeField] int numberOfLoadedBullets;
    [SerializeField] int damagePerShot;
    [SerializeField] float range;
    [SerializeField] float timeBetweenBullets;

    bool isRealoading = false;

    public bool IsAutomatic { get { return isAutomatic; } }
    public int MaxBullets { get { return maxBullets; } }
    public int CurrentNumberOfBullets { get { return currentNumberOfBullets; } }
    public int ClipSize { get { return clipSize; } }
    public int NumberOfLoadedBullets { get { return numberOfLoadedBullets; } }
    public int DamagePerShot { get { return damagePerShot; } }
    public float Range { get { return range; } }
    public float TimeBetweenBullets { get { return timeBetweenBullets; } }

    public bool CanShoot { get { return numberOfLoadedBullets > 0; } }
    public bool IsReloading { get { return isRealoading; } }

    void Reload()
    {
        int bulletsToLoad = clipSize - numberOfLoadedBullets;
        if (bulletsToLoad > currentNumberOfBullets)
        {
            bulletsToLoad = currentNumberOfBullets;
        }

        numberOfLoadedBullets += bulletsToLoad;

        currentNumberOfBullets -= bulletsToLoad;

        isRealoading = false;
    }

    public void Reload(float delay)
    {
        isRealoading = true;
        Invoke("Reload", delay);
    }

    

    public void addBullets(int bullets)
    {
        currentNumberOfBullets += bullets;
        if(currentNumberOfBullets > maxBullets)
        {
            currentNumberOfBullets = maxBullets;
        }
    }

    public void shootBullet()
    {
        numberOfLoadedBullets -= 1;
    }
}
