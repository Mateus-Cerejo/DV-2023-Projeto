using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "BuildingSO")]
public class BuildingSO : ScriptableObject
{
    [SerializeField] private string type;
    [SerializeField] private List<GameObject> levels;

    public List<GameObject> getLevels()
    {
        return levels;
    }
}
