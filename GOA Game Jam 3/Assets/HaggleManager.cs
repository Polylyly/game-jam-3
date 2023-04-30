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
    bool sold = false;
    public static HaggleManager instance;
    BigotonScript bigInstance;
    bool enteredSoldMode = false;
    private void Awake()
    {
        instance = this;
        bigInstance = GetComponent<BigotonScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        iOpener.onInventoryClosed += () => this.OnInventoryClosed();
        data = GetComponent<ScrapData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartHaggleSequence()
    {
        Debug.Log("Started haggle sequence");
        //bigInstance.ActivateDialoguePanel();
        bigInstance.PlayFirstMsg();

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
        bigInstance.StateValue(value);
        enteredSoldMode = true;
        //done, not sure if it works,,


        //TODO should add dialogue options to either accept the price or haggle with him
        //bigInstance.PlayOptionMsg();
        //done

    }

    public void OnAcceptPrice()
    {
        Money.instance.AddMoney(value);
        value = -1;
        sold =  true;
        //TODO include dialogue where bigoton says goodbye
        bigInstance.PlayGoodbyeMsg();

        //done
        iManager.enterDropMode();
        iOpener.ToggleInventory();
    }

    public void OnHaggleMinigameStart()
    {
        hgv1.Show();
        hgv2.Show();
        GameObject.Find("BigotonDialogue/DialogueBox").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("BigotonDialogue/DialogueBox/Avatar").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("BigotonDialogue/DialogueBox/ActorName").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("BigotonDialogue/DialogueBox/Message").GetComponent<CanvasRenderer>().SetAlpha(0f);
    }

    public void OnHaggleMinigameEnd()
    {
        enteredSoldMode = false;
        hgv1.Hide();
        hgv2.Hide();
        value =  slider.getValue();
        if (useDebugCode) Debug.Log("Haggled value: " + slider.getValue());
        //if the value the player haggled in the minigame is valid, add money
        if (value - data.getValue() < 7)
        {
            if (useDebugCode) Debug.Log("Price accepted, haggle successful");
            //TODO include dialogue for bigoton saying goodbye and telling the player they won
            bigInstance.PlayGoodbyeMsg();

            //done

            Money.instance.AddMoney(value);
            sold = true;
            iManager.enterDropMode();
            iOpener.ToggleInventory();
            GameObject.Find("BigotonDialogue/DialogueBox").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("BigotonDialogue/DialogueBox/Avatar").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("BigotonDialogue/DialogueBox/ActorName").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("BigotonDialogue/DialogueBox/Message").GetComponent<CanvasRenderer>().SetAlpha(1f);
            value = -1;
        }
        else
        {

            //TODO include dialogue for bigoton saying goodbye and telling the player they lost, and that he bought the item for half price
            bigInstance.PlayLosingGoodbyeMsg();

            //done

            value = data.getValue()/2;
            if (useDebugCode) Debug.Log("Price too high, bigoton paid: " + value);
            Money.instance.AddMoney(value);
            sold = true;
            iManager.enterDropMode();
            iOpener.ToggleInventory();
            GameObject.Find("BigotonDialogue/DialogueBox").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("BigotonDialogue/DialogueBox/Avatar").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("BigotonDialogue/DialogueBox/ActorName").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("BigotonDialogue/DialogueBox/Message").GetComponent<CanvasRenderer>().SetAlpha(1f);
            value = -1;
        }
    }
        void OnInventoryClosed()
    {
        //TODO include dialogue for when the player cancels selling by closing their inventory
        if(!sold && InventoryManager.instance.buttonText.text == "Sell")
            bigInstance.PlayCancelMsg();
        iManager.enterDropMode();
        sold = false;
        enteredSoldMode = false;

        //done

    }
    public bool selling(){
        return enteredSoldMode;
    }

}
