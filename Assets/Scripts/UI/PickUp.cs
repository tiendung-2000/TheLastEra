using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemUsed item = collision.gameObject.GetComponent<ItemUsed>();
        if (item != null)
        {
            Debug.Log("Pickup");
            UI_EquipmentManager.instance.AddItem(item.item, 1);
        }
    }
}
