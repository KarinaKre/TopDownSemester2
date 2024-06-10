using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private StateInfo stateInfo;
    [SerializeField] private Image slotImage;
    [SerializeField] private TextMeshProUGUI text_slotAmount;
    private StateManager stateManager;
    [SerializeField] private Toggle toggleState;
    [SerializeField] private GameObject inventorySlotBorder;
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    public void SetStateInfo(StateInfo stateInfo)
    {
        this.stateInfo = stateInfo;
        SetVisulas();
    }
    private void Awake()
    {
        stateManager = FindObjectOfType<StateManager>();
    }

    public void SetVisulas()
    {
        slotImage.sprite = stateInfo.sprite;
        text_slotAmount.SetText(stateInfo.amount.ToString());
        TurnOnOffVisuals(true);
    }

    public void TurnOnOffVisuals(bool value)
    {
        slotImage.gameObject.SetActive(value);
        text_slotAmount.gameObject.SetActive(value);
        toggleState.interactable = value;
        inventorySlotBorder.gameObject.SetActive(false);
    }

    public void TurnOffBorder()
    {
        StartCoroutine(InitiateTurnOffBorder());
    }

    IEnumerator InitiateTurnOffBorder()
    {
        yield return null;
        inventorySlotBorder.SetActive(false);
    }

    public void ShowDescription()
    {
        if (toggleState.isOn)
        {
            inventoryManager.ShowItemDescription(stateInfo);
        }
    }

}
