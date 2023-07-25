using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearchManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI percText;
    [SerializeField] GameObject percSlider;

    private int curResearchPerc;
    public delegate void Win();
    public static event Win onWin;

    private void Start()
    {
        curResearchPerc = PlayerPrefs.GetInt("curResearchPerc", 10);

        percSlider.GetComponent<Slider>().value = curResearchPerc;
        percText.text = curResearchPerc + "%";
    }

    public void IncrementSearch(int amount)
    {
        curResearchPerc = Mathf.Clamp(curResearchPerc + amount, 0, 100);

        PlayerPrefs.SetInt("curResearchPerc", curResearchPerc);

        percSlider.GetComponent<Slider>().value = curResearchPerc;
        percText.text = curResearchPerc + "%";

        if (curResearchPerc == 100)
        {
            onWin?.Invoke();
        }
    }
}
