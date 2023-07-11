using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory<T> : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private float size = 10;
    private List<SlotData<T>> inventoryList = new List<SlotData<T>>();


    public void Add(T item)
    {
        Debug.Log("Adding item to inventory!");
        if (inventoryList.Count < size)
        {
            if (Find(item, out SlotData<T> slot))
            {
                ChangeCount(slot, slot.count++);
                Debug.Log("You have " + slot.data.ToString() + "/" + slot.count++);
            }
            else
            {
                inventoryList.Add(new SlotData<T>(item, 1));
                Debug.Log("You added " + slot.data.ToString());
            }
        }
    }

    private bool Find(T item, out SlotData<T> slot)
    {
        slot = default(SlotData<T>);
        foreach (var value in inventoryList)
        {
            if (value.data.Equals(item))
            {
                slot = value;
                return true;
            }
        }
        return false;
    }

    private bool ChangeCount(SlotData<T> slot, int n_count)
    {
        if (inventoryList.Contains(slot))
        {
            int index = inventoryList.FindIndex(s => s.Equals(slot));
            slot.count = n_count;
            Debug.Log(index + "/" + slot.count);
            inventoryList.ToArray()[index] = slot;
        }
        return false;
    }

    public void Remove()
    {
        Debug.Log("Removing");
    }


}
