using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResearchManager : MonoBehaviour
{
    [SerializeField] private Scroller scroller;

    private int curResearchPerc;

    public void IncrementSearch(int amount)
    {
        curResearchPerc += Mathf.Clamp(curResearchPerc + amount, 0, 100);

        if (curResearchPerc == 100)
        {

        }
    }
}
