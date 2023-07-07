using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSetup : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button delBtn;

    public void setActions(string path)
    {
        delBtn.onClick.AddListener(() => {
            Directory.Delete(path,true);
            File.Delete(path + ".meta");
            Destroy(gameObject);
        });

        playBtn.onClick.AddListener(() => {
            PlayerPrefs.SetString("save Directory ", path);
            SceneManager.LoadScene("Main Scene");
        });
    }
}
