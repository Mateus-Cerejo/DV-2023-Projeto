using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToBattle : MonoBehaviour
{
    public void GoToBattleScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
