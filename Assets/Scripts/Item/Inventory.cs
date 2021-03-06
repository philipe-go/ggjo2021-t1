using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory", fileName = "Inventory.asset")]
[System.Serializable]
public class Inventory : ScriptableObject
{

    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(Item _item, int _stackAmount)
    {
        //we check if we have an inventory or not 
        bool notEmpty = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].item == _item)
            {
                Container[i].AddStack(_stackAmount);
                notEmpty = true;
                break;
            }
        }
        if (!notEmpty)
        {
            Container.Add(new InventorySlot(_item, _stackAmount));
        }
    }

    public void removeItem(Item _item, int _stackAmount)
    {
        //we check if we have an inventory or not 
        bool notEmpty = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].removeStack(_stackAmount);
                notEmpty = true;
                break;
            }
        }
        if (!notEmpty)
        {
            Container.Remove(new InventorySlot(_item, _stackAmount));
        }
    }

}

[System.Serializable]
public class InventorySlot
{
    //Add the slots
    public Item item;
    public int stackAmount;
    public InventorySlot(Item _item, int _stackAmount)
    {
        item = _item;
        stackAmount = _stackAmount;
    }

    //add the stacks of item
    public void AddStack(int value)
    {
        stackAmount += value;
    }

    public void removeStack(int value)
    {
        stackAmount -= value;
    }
}
