using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerLoot", menuName = "Custom/Player Loot")]
public class PlayerLoot : ScriptableObject
{
    [SerializeField] private int initPills = 0;
    [SerializeField] private int curPills;

    private void OnEnable()
    {
        curPills = initPills;
    }

    public int Pills
    {
        get => curPills;
        set => curPills = value;
    }
}
