using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryOpener : MonoBehaviour
{
    public InventoryManager manager;
    public bool isOpen = true;
    public Action onInventoryClosed;

    
    private void Update()
    {
        if (Input.GetButtonDown("ToggleInventory"))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        manager.SelectItem(-1);
        transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeInHierarchy);
        isOpen = transform.GetChild(0).gameObject.activeInHierarchy;
        if (!isOpen) onInventoryClosed();
    }
}
