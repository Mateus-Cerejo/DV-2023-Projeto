using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    [SerializeField] private float viewRadius;

    [SerializeField] private LayerMask obstacleMask;
    [SerializeField] private LayerMask playerMask;


    [SerializeField] private List<Transform> visibleTargets = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Referenced");
    }

    // Update is called once per frame
    void Update()
    {

    }



    public Transform FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] obstacleTargets = Physics.OverlapSphere(transform.position, viewRadius, obstacleMask);
        Collider[] playerTargets = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        Debug.Log("Obstacles "+ obstacleTargets.Length);
        Debug.Log("Players "+ playerTargets.Length);


        string infoMessage = "";

        //N�o encontra obst�culos
        if (obstacleTargets.Length == 0 || obstacleTargets == null)
        {
            infoMessage += "N�o h� obst�culos � vista";
            //Encontra obst�culos
            if (playerTargets.Length == 0 || playerTargets == null)
            {
                infoMessage += "\nN�o h� jogadores � vista";
                Debug.Log(infoMessage);

                return null;
            }
            infoMessage += "\nMas h� " + playerTargets.Length + " jogador � vista";

            for (int i = 0; i < playerTargets.Length; i++) {
                infoMessage += "\nH� " + playerTargets[i].gameObject + " jogador Object � vista";
            }
            Debug.Log(infoMessage);

            visibleTargets.Add(playerTargets[0].transform);

            return playerTargets[0].transform;
        }
        else if (obstacleTargets.Length > 0)
        {
            infoMessage += "H� " + obstacleTargets.Length + " obst�culos � vista";

            float minDistance = 50;
            Transform chosenTargetTransform = null;

            if (playerTargets.Length != 0 && playerTargets != null)
            {
                visibleTargets.Add(playerTargets[0].transform);
                infoMessage += "H� " + playerTargets.Length + " jogadores � vista";

                Transform target = playerTargets[0].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (distanceToTarget < minDistance / 2)
                {
                    minDistance = distanceToTarget;
                    chosenTargetTransform = target;
                }
            }
            

            for (int i = 0; i < obstacleTargets.Length; i++)
            {
                Transform target = obstacleTargets[i].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (distanceToTarget < minDistance && chosenTargetTransform == null)
                {
                    minDistance = distanceToTarget;
                    chosenTargetTransform = target;
                }
                visibleTargets.Add(target);
                //}

            }

            return chosenTargetTransform;
        }

        Debug.Log("N�o h� obst�culos\nNem jogadores visiveis");
        return null;
    }

    public float ViewRadius
    {
        get => viewRadius;
        set => viewRadius = value;
    }

    public List<Transform> VisibleTargets
    {
        get => visibleTargets;
        set => visibleTargets = value;
    }

 	

}
