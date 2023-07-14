using HotQueen.Inventory;
using UnityEngine;

public class InventoryDemo : Inventory<DemoData>
{
    private void Update()
    {
        DemoData dataA = new DemoData("HelloWorld","Hello world, programmed to work but not to fell... don´t even know if this is real.");
        DemoData dataB = new DemoData("Gellow","Gellow is yellow, so hello!!");
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
