using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IPointerClickHandler, IEndDragHandler, IDragHandler
{
    private Transform parent;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    private void Awake()
    {
        parent = transform.parent;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Inventory.Instance.DebugTHIS();
        canvasGroup.blocksRaycasts = false;
        if (transform.parent.name == "Content")
        {
            Inventory.Instance.RemoveFromUnequiped(GetComponent<ItemPreview>().GetItem());
        }
        else
        {
            Inventory.Instance.UnEquipeItem(GetComponent<ItemPreview>().GetItem());
        }
        transform.SetParent(GameObject.Find("Canvas").transform);
        Inventory.Instance.DebugTHIS();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (!transform.parent.CompareTag("ItemSlot"))
        {
            transform.SetParent(parent);
            Inventory.Instance.AddItem(GetComponent<ItemPreview>().GetItem());
        }
        Inventory.Instance.DebugTHIS();
    }

    public void BackToInventory()
    {
        transform.SetParent(parent);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (TryGetComponent(out ItemPreview itemPrev))
        {
            itemPrev.OpenDetailedItem();
        }
    }
}
