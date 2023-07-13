using HotQueen.Inventory;
using UnityEngine;

public class InventoryDemo : Inventory<DemoData>
{
    private void Update()
    {
        DemoData dataA = new DemoData("HelloWorld");
        DemoData dataB = new DemoData("Gellow");
        if (Input.GetKeyDown(KeyCode.A))
        {
            Add(dataA);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Add(dataB);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Remove(dataA);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Remove(dataB);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Remove(dataA, true);
            Remove(dataB, true);
        }
    }
}
