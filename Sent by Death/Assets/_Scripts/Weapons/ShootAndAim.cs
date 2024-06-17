using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootAndAim : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab, text;
    public int currentAmmo = -1;

    public TextMeshProUGUI ammoText;

    [SerializeField] float reloadTime;
    [SerializeField] int maxAmmo;
    bool isReloading = false;
    public Animator anim;

    public void Start()
    {
        text.SetActive(true);

        currentAmmo = maxAmmo;
        ammoText.text = currentAmmo.ToString("Ammo: 0");
    }
    void Update()
    {
        if (isReloading)
            return;

        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            
        }
        
        
    }

    IEnumerator Reload()
    {
        isReloading = true;
        ammoText.text = "Reloading...";
        print("reload");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        ammoText.text = currentAmmo.ToString("Ammo: 0");
    }
    void Shoot()
    {
        anim.SetTrigger("Fire");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        currentAmmo--;
        ammoText.text = currentAmmo.ToString("Ammo: 0");
    }
}
