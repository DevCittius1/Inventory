using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace HotQueen.Inventory
{

    public abstract class Inventory<T> : MonoBehaviour where T : struct
    {
        [SerializeField] private float size = 10;
        private List<SlotData<T>> inventoryList = new List<SlotData<T>>();

        //Callback
        public UnityEvent<List<SlotData<T>>> OnInventoryUpdated;

        public void Add(T item)
        {
            Debug.Log("Adding item to inventory!");
            if (inventoryList.Count < size)
            {
                SlotData<T> slot = new SlotData<T>();
                if (TryFind(item, out slot))
                {
                    ChangeCount(slot, slot.count += 1);
                }
                else
                {
                    slot = new SlotData<T>(item, 1);
                    inventoryList.Add(slot);
                }
                OnInventoryUpdated?.Invoke(inventoryList);
            }
        }

        private bool TryFind(T item, out SlotData<T> slot)
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

        private bool TryFind(T item)
        {
            foreach (var value in inventoryList)
            {
                if (value.data.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        private bool TryGetIndex(T item, out int index)
        {
            if (TryFind(item, out SlotData<T> slot))
            {
                index = inventoryList.FindIndex(s => s.Equals(slot));
                return true;

            }
            index = -1;
            return false;
        }

        private bool ChangeCount(SlotData<T> slot, int n_count)
        {
            if (inventoryList.Contains(slot))
            {
                int index = inventoryList.FindIndex(s => s.Equals(slot));
                slot.count = n_count;
                inventoryList.RemoveAt(index);
                inventoryList.Insert(index, slot);
                Debug.Log(index + "/" + inventoryList.ElementAt(index).count);
            }
            return false;
        }

        public void Remove(T target, bool clear = false)
        {
            if (TryGetIndex(target, out int index))
            {
                SlotData<T> slot = inventoryList.ElementAt(index);
                if (slot.count > 0 && !clear)
                {
                    ChangeCount(slot, slot.count -= 1);
                }

                if (slot.count == 0)
                {
                    inventoryList.RemoveAt(index);
                }

                OnInventoryUpdated?.Invoke(inventoryList);

            }
        }

    }

}