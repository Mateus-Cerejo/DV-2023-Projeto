using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "BuildingSO")]
public class BuildingSO : ScriptableObject
{
    [SerializeField] private string type;
    [SerializeField] private List<GameObject> levels;
    [SerializeField] private List<Materials> levelCosts;
    [SerializeField] private List<string> upgradeText;

    public List<GameObject> getLevels()
    {
        return levels;
    }

    public List<Materials> getLevelCosts()
    {
        return levelCosts;
    }

    public List<string> GetUpgradeText() 
    {
        return upgradeText; 
    }

    public int getNumOfLevels() 
    { 
        return levels.Capacity;
    }
}
