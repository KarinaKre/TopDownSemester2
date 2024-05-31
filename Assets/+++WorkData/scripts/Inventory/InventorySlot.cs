using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image slotImage;
    [SerializeField] private TextMeshProUGUI text_slotAmount;

    public void SetInventorySlot(Sprite slotSprite,string slotAmount)
    {
        slotImage.sprite = slotSprite;
        text_slotAmount.SetText(slotAmount);
    }
}
