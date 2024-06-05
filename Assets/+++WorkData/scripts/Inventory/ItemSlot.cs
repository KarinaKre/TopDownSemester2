using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;

    [SerializeField]
    private int maxNumberOfItems;

    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image itemImage;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    public Image itemDescriptionImage;
    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;
    public Sprite emptySprite;


    private void Start()
    {  
        inventoryManager = GameObject.Find("CanvasUI").GetComponent<InventoryManager>();
        if(itemName != "")
            RefreshItemSlot();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite,string itemDescription)
    {
        if(isFull)
        {
            return quantity;
        }

        this.itemName = itemName;
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;

        this.itemDescription = itemDescription;


        this.quantity += quantity;
       if( this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;
        

             int extraItems = this.quantity - maxNumberOfItems;
             this.quantity = maxNumberOfItems;
             return extraItems;

        }

        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;
    }

   


    public void OnLeftClick()
    {
        if(itemName != "")
            RefreshItemSlot();  
    }

    public void RefreshItemSlot()
    {
        if (thisItemSelected)
        {
            //  inventoryManager.UseItem(itemName);
            // this.quantity -= 1;
            //quantityText.text = this.quantity.ToString();

            if (this.quantity < 1)
            {
                EmptySlot();
            }
        }
        else
        {
            
            selectedShader.SetActive(true);
            thisItemSelected = true;
            itemNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
            quantityText.text = this.quantity.ToString();
            itemImage.sprite = itemSprite;
            itemDescriptionImage.sprite = itemSprite;
            itemImage.enabled = true;
            if (itemDescriptionImage.sprite == null)
            {
                itemDescriptionImage.sprite = emptySprite;
            }

        }
    }


    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemNameText.text = "";
        itemDescriptionText.text = "";
        itemImage.sprite = emptySprite;
        itemDescriptionImage.sprite = emptySprite;
    }
}
