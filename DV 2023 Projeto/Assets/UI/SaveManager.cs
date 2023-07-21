using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
    }
    
    void OnApplicationQuit()
    {
        Save();
        PlayerPrefs.DeleteAll();
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
        
    }
}
