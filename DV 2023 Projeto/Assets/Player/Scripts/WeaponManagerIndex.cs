using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponManagerIndex", menuName = "FPS/WeaponManagerIndex", order = 0)]
public class WeaponManagerIndex : ScriptableObject {
    [SerializeField] private int _currentRangedIndex = 0;
    [SerializeField] private int _currentMeleeIndex = 0;

    public int currentRangedIndex
    {
        get => _currentRangedIndex;
        set => _currentRangedIndex = value;
    }

    public int currentMeleeIndex
    {
        get => _currentMeleeIndex;
        set => _currentMeleeIndex = value;
    }
}
