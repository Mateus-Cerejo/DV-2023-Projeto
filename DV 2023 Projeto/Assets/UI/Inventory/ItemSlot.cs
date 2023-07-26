using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ItemSlot : MonoBehaviour, IDropHandler
{
    protected bool full;
    public abstract void OnDrop(PointerEventData eventData);

    public void SetItem(ItemPreview item)
    {
        full = true;
        Instantiate(item, transform);
    }

    public void RemoveItem() { full = false; }
}
