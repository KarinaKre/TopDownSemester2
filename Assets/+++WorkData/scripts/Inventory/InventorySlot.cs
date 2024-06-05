using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image slotImage;
    [SerializeField] private TextMeshProUGUI text_slotAmount;
    private StateManager stateManager;
    [SerializeField] private Toggle toggleState;

    private void Awake()
    {
        stateManager = FindObjectOfType<StateManager>();
    }

    public void SetInventorySlot(Sprite slotSprite,int slotAmount)
    {
        slotImage.sprite = slotSprite;
        text_slotAmount.SetText(slotAmount.ToString());
        
    }

    private void EmptySlot()
    {
        
    }

}
