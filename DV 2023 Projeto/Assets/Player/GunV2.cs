using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunV2 : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float fireRate, spread, range, reloadTime, burstFireTime;
    [SerializeField] private int magazineSize, bulletsPerTap, maxAmmo;
    private int bulletsLeft, bulletsShot;
    [SerializeField] private bool allowButtonHold;

    private bool shooting, readyToShoot, reloading;

    [SerializeField] private Camera fpsCam;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private RaycastHit rayHit;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private GameObject muzzleFlash,bulletHoleGraphic;
    [SerializeField] private TextMeshProUGUI ammoCounter;
    [SerializeField] private Image reloadRadialImage;
    private float reloadProgress = 0f;

    void OnEnable() {
        ammoCounter.text = gameObject.name+":\n"+bulletsLeft+"/"+maxAmmo;
    }

    private void Start()
    {
        bulletsLeft = magazineSize;
        reloading=false;
        reloadRadialImage.gameObject.SetActive(false);        
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();
        UpdateReloadIndicator();
        if(bulletsLeft<0) bulletsLeft = 0;
        ammoCounter.text = gameObject.name+":\n"+bulletsLeft+"/"+maxAmmo;
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetButton("Fire1");
        else shooting = Input.GetButtonDown("Fire1");

        if(Input.GetButtonDown("Reload") && bulletsLeft < magazineSize && !reloading && maxAmmo>0) Reload();

        if(readyToShoot && shooting && !reloading && bulletsLeft>0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }

    }

    private void Shoot()
    {
        readyToShoot = false;

        float x = Random.Range(-spread,spread);
        float y = Random.Range(-spread,spread);

        Vector3 direction = fpsCam.transform.forward + new Vector3(x,y,0);

        if(Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range))
        {
            Debug.Log(rayHit.collider.name);

            if(rayHit.collider.CompareTag("Enemy")) rayHit.collider.GetComponent<Enemy>().TakeDamage(damage);
        }

        Destroy(Instantiate(muzzleFlash,attackPoint.position,Quaternion.identity),0.5f);
        Destroy(Instantiate(bulletHoleGraphic,rayHit.point,Quaternion.LookRotation(rayHit.normal)),0.5f);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShoot",fireRate/100);

        if(bulletsShot>0 && bulletsLeft>0) Invoke("Shoot",burstFireTime/100);
    }

    private void ResetShoot()
    {
        readyToShoot=true;
    }

    private void Reload()
    {
        reloading = true;
        reloadRadialImage.gameObject.SetActive(true);

        float remainingReloadProgress = (reloadTime - reloadProgress) * (1f - reloadRadialImage.fillAmount);

       reloadProgress = remainingReloadProgress;

        Invoke("ReloadFinished", reloadTime - reloadProgress);
    }

    private void ReloadFinished()
    {
        int bulletsToLoad = magazineSize - bulletsLeft;

        if(bulletsToLoad>maxAmmo)
        {
            bulletsLeft = bulletsLeft+maxAmmo;
            maxAmmo = 0;
        }
        else
        {
            bulletsLeft = magazineSize;
            maxAmmo -= bulletsToLoad;
        }
        reloading = false;
        reloadRadialImage.gameObject.SetActive(false);
    }

    private void UpdateReloadIndicator()
    {
        // Update the reload progress in the Radial Image
        if (reloading)
        {
            reloadProgress += Time.deltaTime;
            reloadRadialImage.fillAmount = Mathf.Clamp01(reloadProgress / reloadTime);
        }
    }

    public bool IsReloading()
    {
        return reloading;
    }
}
