using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {
    //creating an inventory for the player

    public GameObject[] inventory = new GameObject[2];
    public Image[] inventorySlots = new Image[2];

    public void AddItem(GameObject item)
    {

        bool itemAdded = false;

        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory [i] == null)
            {
                inventory[i] = item;
                inventorySlots[i].overrideSprite = item.GetComponent<SpriteRenderer>().sprite; //get sprite for cup to put in item slot
                Debug.Log(item.name + " was added to inventory");
                itemAdded = true;
                break;
            }
        }

        //if inventory full
        if (!itemAdded)
        {
            Debug.Log("Inventory is Full!");
        }
    }

    public bool FindItem(GameObject item) //check if we have the item needed to interact with object
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory [i] == item)
            {
                //found the cup
                return true;
            }
        }
        //if item not found
        return false;
    }

    

}
