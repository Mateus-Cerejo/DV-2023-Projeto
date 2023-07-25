using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHealth : MonoBehaviour
{
    [SerializeField] private float health = 100;
    public void TakeDmg(float dmg)
    {
        health -= dmg;
        Debug.Log("hit");
        if (health <= 0)
        {
            GameObject parentObject = transform.parent.gameObject;
            Destroy(parentObject);
            return;
        }
    }
}
