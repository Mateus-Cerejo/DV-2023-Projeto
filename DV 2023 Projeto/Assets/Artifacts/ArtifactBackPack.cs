using UnityEngine;

[CreateAssetMenu(fileName = "ArtifactBackPack", menuName = "FPS/ArtifactBackPack", order = 0)]
public class ArtifactBackPack : ScriptableObject {
    [SerializeField] private int _artifactEquipLimit = 4;

    [SerializeField] private int _powerArtifactQuantityStored = 0;
    [SerializeField] private int _powerArtifactQuantityEquiped = 0;
    [SerializeField] private float _powerArtifactEffect = 0.20f;

    [SerializeField] private int _speedArtifactQuantityStored = 0;
    [SerializeField] private int _speedArtifactQuantityEquiped = 0;
    [SerializeField] private float _speedArtifactEffect = 0.20f;

    [SerializeField] private int _lifeArtifactQuantityStored = 0;
    [SerializeField] private int _lifeArtifactQuantityEquiped = 0;
    [SerializeField] private float _lifeArtifactEffect = 0.20f;

    [SerializeField] private int _looterArtifactQuantityStored = 0;
    [SerializeField] private int _looterArtifactQuantityEquiped = 0;
    [SerializeField] private float _looterArtifactEffect = 0.20f;

    [SerializeField] private int _allInOneArtifactQuantityStored = 0;
    [SerializeField] private int _allInOneArtifactQuantityEquiped = 0;
    [SerializeField] private float _allInOneArtifactEffect = 0.20f;

    [SerializeField] private int _iceAuraArtifactQuantityStored = 0;
    [SerializeField] private int _iceAuraArtifactQuantityEquiped = 0;
    [SerializeField] private float _iceAuraArtifactEffect = 0.5f;
    [SerializeField] private float _iceAuraArtifactDuration = 2f;

    public int artifactEquipLimit
    {
        get => _artifactEquipLimit;
        set => _artifactEquipLimit = value;
    }

    public int powerArtifactQuantityStored
    {
        get => _powerArtifactQuantityStored;
        set => _powerArtifactQuantityStored = value;
    }

    public int powerArtifactQuantityEquiped
    {
        get => _powerArtifactQuantityEquiped;
        set => _powerArtifactQuantityEquiped = value;
    }

    public float powerArtifactEffect
    {
        get => _powerArtifactEffect;
        set => _powerArtifactEffect = value;
    }

    public int speedArtifactQuantityStored
    {
        get => _speedArtifactQuantityStored;
        set => _speedArtifactQuantityStored = value;
    }

    public int speedArtifactQuantityEquiped
    {
        get => _speedArtifactQuantityEquiped;
        set => _speedArtifactQuantityEquiped = value;
    }

    public float speedArtifactEffect
    {
        get => _speedArtifactEffect;
        set => _speedArtifactEffect = value;
    }

    public int lifeArtifactQuantityStored
    {
        get => _lifeArtifactQuantityStored;
        set => _lifeArtifactQuantityStored = value;
    }

    public int lifeArtifactQuantityEquiped
    {
        get => _lifeArtifactQuantityEquiped;
        set => _lifeArtifactQuantityEquiped = value;
    }

    public float lifeArtifactEffect
    {
        get => _lifeArtifactEffect;
        set => _lifeArtifactEffect = value;
    }

    public int looterArtifactQuantityStored
    {
        get => _looterArtifactQuantityStored;
        set => _looterArtifactQuantityStored = value;
    }

    public int looterArtifactQuantityEquiped
    {
        get => _looterArtifactQuantityEquiped;
        set => _looterArtifactQuantityEquiped = value;
    }

    public float looterArtifactEffect
    {
        get => _looterArtifactEffect;
        set => _looterArtifactEffect = value;
    }

    public int allInOneArtifactQuantityStored
    {
        get => _allInOneArtifactQuantityStored;
        set => _allInOneArtifactQuantityStored = value;
    }

    public int allInOneArtifactQuantityEquiped
    {
        get => _allInOneArtifactQuantityEquiped;
        set => _allInOneArtifactQuantityEquiped = value;
    }

    public float allInOneArtifactEffect
    {
        get => _allInOneArtifactEffect;
        set => _allInOneArtifactEffect = value;
    }

    public int iceAuraArtifactQuantityStored
    {
        get => _iceAuraArtifactQuantityStored;
        set => _iceAuraArtifactQuantityStored = value;
    }

    public int iceAuraArtifactQuantityEquiped
    {
        get => _iceAuraArtifactQuantityEquiped;
        set => _iceAuraArtifactQuantityEquiped = value;
    }

    public float iceAuraArtifactEffect
    {
        get => _iceAuraArtifactEffect;
        set => _iceAuraArtifactEffect = value;
    }

    public float iceAuraArtifactDuration
    {
        get => _iceAuraArtifactDuration;
        set => _iceAuraArtifactDuration = value;
    }

    public int getEquipedAmount()
    {
        return powerArtifactQuantityEquiped + speedArtifactQuantityEquiped + lifeArtifactQuantityEquiped + looterArtifactQuantityEquiped + allInOneArtifactQuantityEquiped + iceAuraArtifactQuantityEquiped;
    }

    public void collectPowerArtifact()
    {
        powerArtifactQuantityStored++;
    }

    public void equipPowerArtifact()
    {
        if(getEquipedAmount()<=artifactEquipLimit && powerArtifactQuantityStored>0)
        {
            powerArtifactQuantityEquiped++;
            powerArtifactQuantityStored--;
        }
    }

    public void collectSpeedArtifact()
    {
        speedArtifactQuantityStored++;
    }

    public void equipSpeedArtifact()
    {
        if(getEquipedAmount()<=artifactEquipLimit && speedArtifactQuantityStored>0)
        {
            speedArtifactQuantityEquiped++;
            speedArtifactQuantityStored--;
        }
    }

    public void collectLifeArtifact()
    {
        lifeArtifactQuantityStored++;
    }

    public void equipLifeArtifact()
    {
        if(getEquipedAmount()<=artifactEquipLimit && lifeArtifactQuantityStored>0)
        {
            lifeArtifactQuantityEquiped++;
            lifeArtifactQuantityStored--;
        }
    }

    public void collectLooterArtifact()
    {
        looterArtifactQuantityStored++;
    }

    public void equipLooterArtifact()
    {
        if(getEquipedAmount()<=artifactEquipLimit && looterArtifactQuantityStored>0)
        {
            looterArtifactQuantityEquiped++;
            looterArtifactQuantityStored--;
        }
    }

    public void collectAllInOneArtifact()
    {
        allInOneArtifactQuantityStored++;
    }

    public void equipAllInOneArtifact()
    {
        if(getEquipedAmount()<=artifactEquipLimit && allInOneArtifactQuantityStored>0)
        {
            allInOneArtifactQuantityEquiped++;
            allInOneArtifactQuantityStored--;
        }
    }

    public void collectIceAuraArtifact()
    {
        iceAuraArtifactQuantityStored++;
    }

    public void equipIceAuraArtifact()
    {
        if(getEquipedAmount()<=artifactEquipLimit && iceAuraArtifactQuantityStored>0)
        {
            iceAuraArtifactQuantityEquiped++;
            iceAuraArtifactQuantityStored--;
        }
    }
}
