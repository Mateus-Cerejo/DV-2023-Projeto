using UnityEngine;
using UnityEngine.Events;

public class UpgradableBuilding : MonoBehaviour
{
    [SerializeField] private BuildingSO levels;
    [SerializeField] private MaterialsManager playerResources;
    [SerializeField] private GameObject actionBox;

    private GameObject building;
    private int curLevel = 0;

    private void Start()
    {
        curLevel = PlayerPrefs.GetInt(gameObject.name, 0);
        building = Instantiate(levels.getLevels()[curLevel], transform.position, transform.rotation, transform);
    }

     public bool Upgrade()
    {
        if (curLevel + 1 < levels.getNumOfLevels())
        {
            if (playerResources.Buy(levels.getLevelCosts()[curLevel]))
            {
                Destroy(building);
                PlayerPrefs.SetInt(gameObject.name, PlayerPrefs.GetInt(gameObject.name, 0) + 1);
                building = Instantiate(levels.getLevels()[++curLevel], transform.position, transform.rotation, transform);
                CloseActionBox();
                return true;
            }
        }
        return false;
    }

    public void OpenActionBox()
    {
        actionBox.GetComponent<ActionBox>().Open(curLevel, levels, this);
        actionBox.SetActive(true);
    }

    public void CloseActionBox()
    {
        actionBox.SetActive(false);
    }

    public int GetCurLevel()
    {
        return curLevel;
    }
}
