using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(player, transform.position , Quaternion.identity);
            
        }
    }
}
