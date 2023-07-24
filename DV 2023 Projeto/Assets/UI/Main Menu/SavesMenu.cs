using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavesMenu : MonoBehaviour
{
    [SerializeField] private GameObject errorCreating;
    [SerializeField] private GameObject saveOptions;
    [SerializeField] private TextMeshProUGUI inputField;
    [SerializeField] private Transform savesDisplay;
    [SerializeField] private GameObject savePrefab;


    private string SAVES_FOLDER;

    private void Start()
    {
        SAVES_FOLDER = Application.dataPath + "/Saves/";

        if (!Directory.Exists(SAVES_FOLDER))
        {
            Directory.CreateDirectory(SAVES_FOLDER);
        }

        DisplaySaves();
    }

    public void NewSave()
    {
        saveOptions.SetActive(true);
    }
    
    public void CreateNewSave()
    {
        string saveName = inputField.text;

        if (Directory.Exists(SAVES_FOLDER + saveName))
        {
            // Mostrar mensagem de erro
            GameObject instance = Instantiate(errorCreating);
            instance.GetComponent<TextMeshProUGUI>().SetText("You already have a save with that name!");
            instance.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
            Destroy(instance, 3);
            return;
        }

        // Criar pasta e save novo
        Directory.CreateDirectory(SAVES_FOLDER + saveName);
        File.WriteAllText(SAVES_FOLDER + saveName + "/"+ saveName + ".txt", "TESTE");

        PlayerPrefs.SetString("save Directory", SAVES_FOLDER + saveName);

        SaveObject save = new SaveObject();
        save.Load();
        string inJSON = JsonUtility.ToJson(save);
        File.WriteAllText(PlayerPrefs.GetString("save Directory") + "/" + Path.GetFileName(PlayerPrefs.GetString("save Directory")) + ".txt", inJSON);

        SceneManager.LoadScene("City Scene");
    }

    private void OnEnable()
    {
        
    }

    public void DeleteSave(string saveName)
    {
        Directory.Delete(SAVES_FOLDER + saveName);
    }

    public void CancelCreate()
    {
        saveOptions.SetActive(false);
    }

    public void Play(string fileName)
    {
        
    }

    public void DisplaySaves()
    {
        string[] aDir = Directory.GetDirectories(SAVES_FOLDER);

        foreach (string sDir in aDir)
        {
            GameObject instance = Instantiate(savePrefab, savesDisplay);
            instance.GetComponent<SaveSetup>().setActions(sDir);
        }
        /*
        Image image = null;

        if (image != null) {
            image.sprite = Resources.Load<Sprite>("Saves/test"); 
        }

        image.sprite = Resources.Load<Sprite>("Saves/test");
        */
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}
