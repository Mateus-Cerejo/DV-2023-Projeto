using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearchManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI percText;
    [SerializeField] GameObject percSlider;
    [SerializeField] GameObject winPane;

    private int curResearchPerc;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => SaveManager.Instance.ready);

        curResearchPerc = PlayerPrefs.GetInt("curResearchPerc", 10);

        percSlider.GetComponent<Slider>().value = curResearchPerc;
        percText.text = curResearchPerc + "%";

        SetSearch(PlayerPrefs.GetInt("curResearchPerc",0));
    }

    public void SetSearch(int amount)
    {
        curResearchPerc = Mathf.Clamp(amount, 0, 100);

        percSlider.GetComponent<Slider>().value = curResearchPerc;
        percText.text = curResearchPerc + "%";

        if (curResearchPerc >= 100)
        {
            Win();
        }
    }

    public void Win()
    {
        Instantiate(winPane, GameObject.Find("Canvas").transform);

        PauseMenu.Instance.enabled = false;
    }
}
