using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArtifactSlot : ItemSlot
{
    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (Inventory.Instance.EquipeArtifact(eventData.pointerDrag.GetComponent<ItemPreview>().GetItem()))
            {
                eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                eventData.pointerDrag.transform.SetParent(transform.parent);
            }
        }
    }
}
