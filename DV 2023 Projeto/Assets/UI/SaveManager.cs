using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public bool ready = false;
    public static SaveManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    IEnumerator Start()
    {
        Inventory.Instance.gameObject.SetActive(true);
        yield return new WaitUntil(() => Inventory.Instance);
        Inventory.Instance.gameObject.SetActive(false);

        Load();
        ready = true;
    }

    void OnApplicationQuit()
    {
        Save();
       // PlayerPrefs.DeleteAll();
    }

    public void Save()
    {
        SaveObject save = new SaveObject();
        save.Save();
        string inJSON = JsonUtility.ToJson(save);
        File.WriteAllText(PlayerPrefs.GetString("save Directory") + "/" + Path.GetFileName(PlayerPrefs.GetString("save Directory")) + ".txt", inJSON);
    }

    public void Load()
    {
        SaveObject save = JsonUtility.FromJson<SaveObject>(File.ReadAllText(PlayerPrefs.GetString("save Directory") + "/" + Path.GetFileName(PlayerPrefs.GetString("save Directory")) + ".txt"));
        save.Load();
    }
}
