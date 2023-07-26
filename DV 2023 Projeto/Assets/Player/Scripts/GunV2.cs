using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunV2 : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private ArtifactBackPack abp;
    [SerializeField] private float fireRate, spread, range, reloadTime, burstFireTime;
    [SerializeField] private int magazineSize, bulletsToShoot, maxAmmo;
    private int bulletsLeft, bulletsShot;
    [SerializeField] private bool allowButtonHold, isShotgun;

    private bool shooting, readyToShoot, reloading;

    [SerializeField] private Camera fpsCam;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private RaycastHit rayHit;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private GameObject muzzleFlash, bulletHoleGraphic, enemyHitGraphic;
    [SerializeField] private Transform muzzleFlashPosition;
    [SerializeField] private TextMeshProUGUI ammoCounter;
    [SerializeField] private Image reloadRadialImage;
    private float reloadProgress = 0f;

    [SerializeField] private AudioSource shootingAudioSource;
    [SerializeField] private AudioSource reloadingAudioSource;

    void OnEnable() {
        ammoCounter.text = gameObject.name+":"+bulletsLeft+"/"+maxAmmo;
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
        ammoCounter.text = gameObject.name+":"+bulletsLeft+"/"+maxAmmo;
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetButton("Fire1");
        else shooting = Input.GetButtonDown("Fire1");

        if(Input.GetButtonDown("Reload") && bulletsLeft < magazineSize && !reloading && maxAmmo>0) Reload();

        if(readyToShoot && shooting && !reloading && bulletsLeft>0)
        {
            bulletsShot = bulletsToShoot;
            Shoot();
        }

    }

    private void Shoot()
    {
        readyToShoot = false;

        if (shootingAudioSource != null)
        {
            shootingAudioSource.Play();
        }

        if (isShotgun)
        {
            Destroy(Instantiate(muzzleFlash, muzzleFlashPosition.position, attackPoint.rotation), 0.1f);
            for (int i = 0; i < bulletsToShoot; i++)
            {
                Vector3 targetPosition = fpsCam.transform.position + fpsCam.transform.forward * range;

                // Calculate horizontal spread within the XZ plane
                float xSpread = Random.Range(-spread, spread);
                float ySpread = Random.Range(-spread, spread);
                float zSpread = Random.Range(-spread, spread);

                // Apply horizontal spread to the target position
                targetPosition = new Vector3(
                    targetPosition.x + xSpread,
                    targetPosition.y + ySpread, // Keep the y-position unchanged for horizontal spread
                    targetPosition.z + zSpread
                );

                // Calculate the direction from the camera position to the modified target position
                Vector3 direction = direction = targetPosition - fpsCam.transform.position;

                GameObject instantiatedMuzzleFlash = Instantiate(muzzleFlash, muzzleFlashPosition.position, attackPoint.rotation);
                instantiatedMuzzleFlash.transform.parent = muzzleFlashPosition; // Set the gun barrel as the parent
                Destroy(instantiatedMuzzleFlash, 0.1f);

                // Create a layer mask to ignore the player layer
                int layerMask = 31 << LayerMask.NameToLayer("Player");
                layerMask = ~layerMask; // Invert the layer mask to exclude the player layer

                if (Physics.Raycast(fpsCam.transform.position, direction.normalized, out rayHit, range))
                {
                    if (rayHit.collider.GetComponent<BruteStats>() != null)
                    {
                        rayHit.collider.GetComponent<BruteStats>().TakeDamage(damage + damage * abp.powerArtifactQuantityEquiped * abp.powerArtifactEffect + damage * abp.allInOneArtifactQuantityEquiped * abp.allInOneArtifactEffect);
                        Destroy(Instantiate(enemyHitGraphic, rayHit.point, Quaternion.LookRotation(rayHit.normal)), 1.0f);
                    }
                    else if (rayHit.collider.GetComponent<ZombieStats>() != null)
                    {
                        rayHit.collider.GetComponent<ZombieStats>().TakeDamage(damage + damage * abp.powerArtifactQuantityEquiped * abp.powerArtifactEffect + damage * abp.allInOneArtifactQuantityEquiped * abp.allInOneArtifactEffect);
                        Destroy(Instantiate(enemyHitGraphic, rayHit.point, Quaternion.LookRotation(rayHit.normal)), 1.0f);
                    }
                    else
                    {
                        Destroy(Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.LookRotation(rayHit.normal)), 0.5f);
                    }
                }
                bulletsShot--;
            }
        }
        else
        {
            Vector3 targetPosition = fpsCam.transform.position + fpsCam.transform.forward * range;

            // Calculate horizontal spread within the XZ plane
            float xSpread = Random.Range(-spread, spread);
            float ySpread = Random.Range(-spread, spread);
            float zSpread = Random.Range(-spread, spread);

            // Apply horizontal spread to the target position
            targetPosition = new Vector3(
                targetPosition.x + xSpread,
                targetPosition.y + ySpread, // Keep the y-position unchanged for horizontal spread
                targetPosition.z + zSpread
            );

            // Calculate the direction from the camera position to the modified target position
            Vector3 direction = direction = targetPosition - fpsCam.transform.position;

            GameObject instantiatedMuzzleFlash = Instantiate(muzzleFlash, muzzleFlashPosition.position, attackPoint.rotation);
            instantiatedMuzzleFlash.transform.parent = muzzleFlashPosition; // Set the gun barrel as the parent
            Destroy(instantiatedMuzzleFlash,0.1f);

            // Create a layer mask to ignore the player layer
            int layerMask = 31 << LayerMask.NameToLayer("Player");
            layerMask = ~layerMask; // Invert the layer mask to exclude the player layer

            if (Physics.Raycast(fpsCam.transform.position, direction.normalized, out rayHit, range))
            {
                if (rayHit.collider.GetComponent<BruteStats>() != null)
                {
                    rayHit.collider.GetComponent<BruteStats>().TakeDamage(damage + damage * abp.powerArtifactQuantityEquiped * abp.powerArtifactEffect + damage * abp.allInOneArtifactQuantityEquiped * abp.allInOneArtifactEffect);
                    Destroy(Instantiate(enemyHitGraphic, rayHit.point, Quaternion.LookRotation(rayHit.normal)), 1.0f);
                }
                else if (rayHit.collider.GetComponent<ZombieStats>() != null)
                {
                    rayHit.collider.GetComponent<ZombieStats>().TakeDamage(damage + damage * abp.powerArtifactQuantityEquiped * abp.powerArtifactEffect + damage * abp.allInOneArtifactQuantityEquiped * abp.allInOneArtifactEffect);
                    Destroy(Instantiate(enemyHitGraphic, rayHit.point, Quaternion.LookRotation(rayHit.normal)), 1.0f);
                }
                else
                {
                    Destroy(Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.LookRotation(rayHit.normal)), 0.5f);
                }
            }
            bulletsShot--;
        }
        
        bulletsLeft--;

        Invoke("ResetShoot",1/fireRate);

        if(bulletsShot>0 && bulletsLeft>0) Invoke("Shoot",1/burstFireTime);
    }

    private void ResetShoot()
    {
        readyToShoot=true;
    }

    private void Reload()
    {
        reloading = true;
        reloadRadialImage.gameObject.SetActive(true);

        if (reloadingAudioSource != null)
        {
            reloadingAudioSource.Play();
        }

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
