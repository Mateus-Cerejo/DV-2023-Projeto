using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CityBehavior : MonoBehaviour
{
    private GameObject previous;
    private GameObject curHit;
    private UpgradableBuilding opened;
    private RaycastHit raycastHit;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            curHit = raycastHit.transform.gameObject;

            if (previous == null)
            {
                previous = curHit;
            }

            // Tratar das animações quando se passa por cima dos elementos da cidade
            if(previous != curHit)
            {
                if (curHit.TryGetComponent(out AnimatableOnHover _))
                {
                    curHit.GetComponent<Animator>().SetBool("IsHovering", true);
                }
                if (previous.TryGetComponent(out AnimatableOnHover _))
                {
                    previous.GetComponent<Animator>().SetBool("IsHovering", false);
                }
            }

            // Tratar dos SFX quando se passa por cima dos elementos da cidade
            if (curHit.TryGetComponent(out AudioSource audioSrc))
            {
                if (previous != curHit)
                {
                    audioSrc.Play();
                }
            }

            if (Input.GetButtonDown("Fire1"))
            {
                if (curHit.CompareTag("UpgradableBuilding"))
                {
                    opened = curHit.GetComponentInParent<UpgradableBuilding>();
                    opened.OpenActionBox();
                }
            }
            previous = curHit;
        }
    }
}