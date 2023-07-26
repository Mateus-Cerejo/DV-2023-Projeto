using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToBattle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => SaveManager.Instance.ready);

        SetText();
    }

    public void GoToBattleScene()
    {
        SaveManager.Instance.Save();
        SceneManager.LoadScene("Level1");
    }

    public void SetText()
    {
        text.SetText("Start battle " + PlayerPrefs.GetInt("day", 0));
    }
}
