using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigotonScript : MonoBehaviour
{
    public GameObject FunctionalBigoton;
    public GameObject Panel;
    public Image actorImage;
    public Text actorName;
    public Text messageText;

    public GameObject haggleButton;
    public GameObject acceptButton;
    //public RectTransform backgroundBox;

    public string FirstMsg;
    public string GoodbyeMsg;
    public string LosingGoodbyeMsg;
    public string cancelMsg;
    public string optionMsg;

    public static BigotonScript instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        FunctionalBigoton.SetActive(false);

        Panel.SetActive(false);


        haggleButton.SetActive(false);
        acceptButton.SetActive(false);

        actorName.text = actorName.text;
        actorImage.sprite = actorImage.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivateBigoton()
    {
        
        FunctionalBigoton.SetActive(true);
    }

    public void StateValue(int x)
    {
        messageText.text = "I can give you " + x + " for that";
    }

    public void PlayFirstMsg()
    {
        messageText.text = FirstMsg;
    }

    public void PlayCancelMsg()
    {
        messageText.text = cancelMsg;
    }
    public void PlayOptionMsg()
    {
        messageText.text = optionMsg;
    }
    public void PlayGoodbyeMsg()
    {
        messageText.text = GoodbyeMsg;
    }
    public void PlayLosingGoodbyeMsg()
    {
        messageText.text = LosingGoodbyeMsg;
    }

    //hide and show buttons + panel
    public void ShowHaggleButton()
    {
        haggleButton = GameObject.Find("HaggleButton");
        haggleButton.SetActive(true);

    }
    public void ShowAcceptButton()
    {
        acceptButton = GameObject.Find("AcceptButton");
        acceptButton.SetActive(true);

    }
    public void HideHaggleButton()
    {
        haggleButton = GameObject.Find("HaggleButton");
        haggleButton.SetActive(false);

    }
    public void HideAcceptButton()
    {
        acceptButton = GameObject.Find("AcceptButton");
        acceptButton.SetActive(false);

    }

    public void ActivateDialoguePanel()
    {
        Panel.SetActive(true);
    }
}
