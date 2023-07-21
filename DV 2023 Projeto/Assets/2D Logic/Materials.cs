using UnityEngine;

[System.Serializable]
public class Materials
{
    [SerializeField] private int wood = 0;
    [SerializeField] private int stone = 0;
    [SerializeField] private int metal = 0;
    [SerializeField] private int pills = 0;

    public Materials(int wood, int stone, int metal, int pills)
    {
        this.wood = Mathf.Clamp(wood, 0, 9999);
        this.stone = Mathf.Clamp(stone, 0, 9999);
        this.metal = Mathf.Clamp(metal, 0, 9999);
        this.pills = Mathf.Clamp(pills, 0, 9999);
    }

    public int GetWood()
    {
        return wood;
    }

    public int GetStone()
    {
        return stone;
    }
    
    public int GetMetal()
    {
        return metal;
    }
    public int GetPills()
    {
        return pills;
    }

    public void SetWood(int amount)
    {
        wood = Mathf.Clamp(amount, 0, 9999);
    }

    public void SetStone(int amount)
    {
        stone = Mathf.Clamp(amount, 0, 9999);
    }

    public void SetMetal(int amount)
    {
        metal = Mathf.Clamp(amount, 0, 9999);
    }
    public void SetPills(int amount)
    {
        pills = Mathf.Clamp(amount, 0, 9999);
    }
}
