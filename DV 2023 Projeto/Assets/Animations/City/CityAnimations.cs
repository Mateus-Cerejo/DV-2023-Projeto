using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CityAnimations : MonoBehaviour
{
    private GameObject selection;
    private RaycastHit raycastHit;

    private void Start()
    {
       
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            if (selection == null)
            {
                selection = raycastHit.transform.gameObject;
            }

            // Tratar das animações quando se passa por cima dos elementos da cidade
            if(selection != raycastHit.transform.gameObject)
            {
                if (raycastHit.transform.gameObject.TryGetComponent(out AnimatableOnHover _))
                {
                    raycastHit.transform.gameObject.GetComponent<Animator>().SetBool("IsHovering", true);
                }
                if (selection.TryGetComponent(out AnimatableOnHover _))
                {
                    selection.GetComponent<Animator>().SetBool("IsHovering", false);
                }
            }

            // Tratar dos SFX quando se passa por cima dos elementos da cidade
            if (raycastHit.transform.gameObject.TryGetComponent(out AudioSource audioSrc))
            {
                if (selection != raycastHit.transform.gameObject)
                {
                    audioSrc.Play();
                    Debug.Log("aqui");
                }
            }
            else
            {

            }


            selection = raycastHit.transform.gameObject;
        }
    }
}