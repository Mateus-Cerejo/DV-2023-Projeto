using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSystem : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    private static int maxActions;
    private int actionsLeft;

    void Start()
    {
        maxActions = 10;
    }
}
