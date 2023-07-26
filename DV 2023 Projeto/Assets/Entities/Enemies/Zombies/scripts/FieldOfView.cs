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

        //Não encontra obstáculos
        if (obstacleTargets.Length == 0 || obstacleTargets == null)
        {
            infoMessage += "Não há obstáculos À vista";
            //Encontra obstáculos
            if (playerTargets.Length == 0 || playerTargets == null)
            {
                infoMessage += "\nNão há jogadores À vista";
                Debug.Log(infoMessage);

                return null;
            }
            infoMessage += "\nMas há " + playerTargets.Length + " jogador à vista";

            for (int i = 0; i < playerTargets.Length; i++) {
                infoMessage += "\nHá " + playerTargets[i].gameObject + " jogador Object à vista";
            }
            Debug.Log(infoMessage);

            visibleTargets.Add(playerTargets[0].transform);

            return playerTargets[0].transform;
        }
        else if (obstacleTargets.Length > 0)
        {
            infoMessage += "Há " + obstacleTargets.Length + " obstáculos à vista";

            float minDistance = 50;
            Transform chosenTargetTransform = null;

            if (playerTargets.Length != 0 && playerTargets != null)
            {
                visibleTargets.Add(playerTargets[0].transform);
                infoMessage += "Há " + playerTargets.Length + " jogadores à vista";

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

        Debug.Log("Não há obstáculos\nNem jogadores visiveis");
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
