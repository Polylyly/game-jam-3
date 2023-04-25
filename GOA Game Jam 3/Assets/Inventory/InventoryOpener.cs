using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpener : MonoBehaviour
{
    public InventoryManager manager;
    public bool isOpen;
    private void Update()
    {
        isOpen = transform.GetChild(0).gameObject.activeInHierarchy;
        if (Input.GetButtonDown("ToggleInventory"))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        manager.SelectItem(-1);
        transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeInHierarchy);
    }
}
