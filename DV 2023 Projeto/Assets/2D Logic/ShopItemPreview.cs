using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemPreview : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject sprite;

    public void SetUp(string name, Sprite sprite)
    {
        nameText.text = name;
        this.sprite.GetComponent<Image>().sprite = sprite;
    }
}
