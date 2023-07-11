using UnityEngine;

public class InventoryDemo : Inventory<DemoData>
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Add(new DemoData("HelloWorld"));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Add(new DemoData("Gellow"));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Remove();
        }
    }
}
