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
    [SerializeField] private TextMeshProUGUI nameText;

    public void setActions(string path)
    {
        nameText.text = Path.GetFileName(path);

        delBtn.onClick.AddListener(() => {
            Directory.Delete(path,true);
            File.Delete(path + ".meta");
            Destroy(gameObject);
        });

        playBtn.onClick.AddListener(() => {
            PlayerPrefs.SetString("save Directory", path);

            SaveObject save = JsonUtility.FromJson<SaveObject>(File.ReadAllText(path + "/" + Path.GetFileName(path) + ".txt"));
            save.Load();

            SceneManager.LoadScene("City Scene");
        });
    }
}
