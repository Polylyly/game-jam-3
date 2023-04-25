using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HaggleManager : MonoBehaviour
{
    public InventoryManager iManager;
    public InventoryOpener iOpener;
    private ScrapData data;
    public int value = -1;
    public HagglingVisibility hgv1;
    public HagglingVisibility hgv2;
    public HagglingSlider slider;
    public bool useDebugCode = false;
    
    // Start is called before the first frame update
    void Start()
    {
        iOpener.onInventoryClosed += () => this.OnInventoryClosed();
        data = GetComponent<ScrapData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (useDebugCode)
        {
            if (Input.GetKeyDown("h"))
            {
                Debug.Log("Start haggle sequence");
                StartHaggleSequence();
            }
            if (Input.GetKeyDown("y"))
            {
                Debug.Log("Start haggle minigame");
                OnHaggleMinigameStart();
            }
            if (Input.GetKeyDown("n"))
            {
                Debug.Log("Price accepted");
                OnAcceptPrice();
            }
        }

        if (slider._pauseToggle == true)
        {
            OnHaggleMinigameEnd();
            slider._pauseToggle = false;
        }
    }

    void StartHaggleSequence()
    {
        //TODO put code to play dialogue for bigoton asking what you want to buy

        //this code opens the inventory and allows the player to sell items
        iManager.enterSellMode();
        if (!iOpener.isOpen) iOpener.ToggleInventory();
    }

    public void OnScrapSold()
    {
        if (useDebugCode) Debug.Log("Scrap value: " + data.getValue());
        //calculates what bigoton is willing to pay for it
        value = Math.Clamp((int) (data.getValue() * UnityEngine.Random.Range(0.3f, 0.9f)), 1, 100);
        if (useDebugCode) Debug.Log("Bigoton's Value: " + value);
        //TODO add dialogue where bigoton states the value he is willing to pay
        //TODO should add dialogue options to either accept the price or haggle with him
        //TODO you can link the 'accept price' button to the OnAcceptedPrice() function
        //and the 'haggle' button to the OnHaggleMinigameStart() function
        iManager.enterDropMode();
        iOpener.ToggleInventory();
    }

    public void OnAcceptPrice()
    {
        Money.instance.AddMoney(value);
        value = -1;
        //TODO include dialogue where bigoton says goodbye
    }

    public void OnHaggleMinigameStart()
    {
        hgv1.Show();
        hgv2.Show();
    }

    public void OnHaggleMinigameEnd()
    {
        hgv1.Hide();
        hgv2.Hide();
        value =  slider.getValue();
        if (useDebugCode) Debug.Log("Haggled value: " + slider.getValue());
        //if the value the player haggled in the minigame is valid, add money
        if (value - data.getValue() < 7)
        {
            if (useDebugCode) Debug.Log("Price accepted, haggle successful");
            //TODO include dialogue for bigoton saying goodbye and telling the player they won
            Money.instance.AddMoney(value);
            value = -1;
        }
        else
        {
           
            //TODO include dialogue for bigoton saying goodbye and telling the player they lost, and that he bought the item for half price
            value = data.getValue()/2;
            if (useDebugCode) Debug.Log("Price too high, bigoton paid: " + value);
            Money.instance.AddMoney(value);
            value = -1;
        }
    }

    void OnInventoryClosed()
    {
        iManager.enterDropMode();
        //TODO include dialogue for when the player cancels selling by closing their inventory
        //something like "ah, don't wanna sell?"
    }
}
