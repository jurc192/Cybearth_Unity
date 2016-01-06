using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WeaponInventory : MonoBehaviour {
    List<Weapon> weapons = new List<Weapon>();

    Weapon currentWeapon;
    public Weapon CurrentWeapon { get { return currentWeapon; } }
    int currentWeaponIdx;

    [SerializeField] PlayerShooting playerShooting;
    [SerializeField] Text ammoInfo;

    void Awake()
    {
        foreach(Weapon weapon in gameObject.GetComponentsInChildren<Weapon>(true))
        {
            weapons.Add(weapon);
        }

        currentWeapon = weapons[0];
        currentWeaponIdx = 0;
    }

    void Update()
    {
        SwitchWeapon();
        ReloadWeapon();
        UpdateAmmoInfo();
    }

    void SwitchWeapon()
    {
        float msw = Input.GetAxisRaw("Mouse ScrollWheel");

        if (msw == 0) return;

        if(msw == 1)
        {
            currentWeaponIdx = (currentWeaponIdx + 1) % weapons.Count;
        }
        else
        {
            currentWeaponIdx -= 1;
            if(currentWeaponIdx < 0)
            {
                currentWeaponIdx = weapons.Count - 1;
            }
        }

        currentWeapon.gameObject.SetActive(false);
        currentWeapon = weapons[currentWeaponIdx];
        currentWeapon.gameObject.SetActive(true);
    }

    void ReloadWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentWeapon.Reload(1f);
            playerShooting.PlayReload();
        }
    }

    void UpdateAmmoInfo()
    {
        string info = currentWeapon.NumberOfLoadedBullets.ToString() + "/" + currentWeapon.CurrentNumberOfBullets.ToString();
        ammoInfo.text = info;
    }
}
