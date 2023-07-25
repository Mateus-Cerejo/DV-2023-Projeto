using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameEvents gameEvents;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameEvents.InvokeEnemyBreached();
            Destroy(other.gameObject);
        }
    }


}
