using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SlotEquipment : MonoBehaviour
{
    public Item item;
    private int count;

    UI_EquipmentManager equipmentController;

    public TextMeshProUGUI textCount;
    public Image icon;
    public Button clearButton;
    public Button usedButton;

    private void Start()
    {
        equipmentController = UI_EquipmentManager.instance;
        clearButton.onClick.AddListener(ClearButton);
        usedButton.onClick.AddListener(UsedItem);
    }

    void UsedItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.health:
                HeathItem healthItem = (HeathItem)GetItemChild(item);               
                UsedHealthItem(healthItem);
                break;
            case Item.ItemType.mana:
                ManaItem manaItem = (ManaItem)GetItemChild(item);
                UsedManaItem(manaItem);
                break;
            default:
                break;
        }
    }

    //Res mana
    private void UsedManaItem(ManaItem manaItem)
    {
        equipmentController.player.ResMana(manaItem.mana, true);
        Debug.Log("After " + equipmentController.player.currentMana);
    }

    //Healing
    private void UsedHealthItem(HeathItem healthItem)
    {   
        equipmentController.player.Healing(healthItem.health, true);
        Debug.Log("After "+ equipmentController.player.currentHealth);
    }
    Item GetItemChild(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.health:
                return (HeathItem)item;
                
            case Item.ItemType.mana:
                return (ManaItem)item;
            default:
                return null;
        }
    }
    void ClearButton()
    {
        SetCount(-count);
        item = null;
    }

    public Item GetItem() { return item; }
    public int GetCount() { return count; }
    public void SetItem(Item _item)
    {
        item = _item;
        icon.sprite = item.icon;

    }
    public void SetCount(int _count)
    {
        count += _count;
        if (count > 99) count = 99;
        if (count <= 0) Active(false, 0);
        else Active(true, 255);
        textCount.text = count.ToString();
    }

    public void Active(bool active, float aColor)
    {
        textCount.gameObject.SetActive(active);
        clearButton.gameObject.SetActive(active);
        icon.color = new Color(255, 255, 255, aColor);
    }

}
