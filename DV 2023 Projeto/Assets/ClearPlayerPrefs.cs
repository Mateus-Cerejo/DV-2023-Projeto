using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlayerPrefs : MonoBehaviour
{
    void Awake()
    {
#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
#endif
    }
}
