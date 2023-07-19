using UnityEngine;

[System.Serializable]
public class Materials
{
    [SerializeField] private int wood;
    [SerializeField] private int stone;
    [SerializeField] private int metal;

    public Materials(int wood, int stone, int metal)
    {
        this.wood = Mathf.Clamp(wood, 0, 9999);
        this.stone = Mathf.Clamp(stone, 0, 9999);
        this.metal = Mathf.Clamp(metal, 0, 9999);
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
}
