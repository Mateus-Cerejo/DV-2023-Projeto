using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int actionsStat;
    private int strengthStat;
    private int atackSpeedStat;
    private int speedStat;
    private int luckStat;

    private void Start()
    {
        actionsStat = PlayerPrefs.GetInt("actionsStat");
        strengthStat = PlayerPrefs.GetInt("strengthStat");
        atackSpeedStat = PlayerPrefs.GetInt("atackSpeedStat");
        speedStat = PlayerPrefs.GetInt("speedStat");
        luckStat = PlayerPrefs.GetInt("luckStat");

    }

    public int getActionsStat() { return actionsStat; }
    public int getStrenghtStat() { return strengthStat; }
    public int getAtackSpeedStat() { return atackSpeedStat; }
    public int getSpeedtat() { return speedStat; }
    public int getLuckStat() { return luckStat; }
}
