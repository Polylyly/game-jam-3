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
        Panel = Panel.GetComponent<GameObject>();
        FunctionalBigoton = FunctionalBigoton.GetComponent<GameObject>();
        haggleButton = haggleButton.GetComponent<GameObject>();
        acceptButton = acceptButton.GetComponent<GameObject>();
        actorName = actorName.GetComponent<Text>();
        actorImage = actorImage.GetComponent<Image>();

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

        FunctionalBigoton = FunctionalBigoton.GetComponent<GameObject>();
        FunctionalBigoton.SetActive(true);
    }

    public void StateValue(int x)
    {
        messageText = messageText.GetComponent<Text>();
        messageText.text = "I can give you " + x + " for that";
    }

    public void PlayFirstMsg()
    {
        messageText = messageText.GetComponent<Text>();
        messageText.text = FirstMsg;
    }

    public void PlayCancelMsg()
    {
        messageText = messageText.GetComponent<Text>();
        messageText.text = cancelMsg;
    }
    public void PlayOptionMsg()
    {
        messageText = messageText.GetComponent<Text>();
        messageText.text = optionMsg;
    }
    public void PlayGoodbyeMsg()
    {
        messageText = messageText.GetComponent<Text>();
        messageText.text = GoodbyeMsg;
    }
    public void PlayLosingGoodbyeMsg()
    {
        messageText = messageText.GetComponent<Text>();
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
        acceptButton = acceptButton.GetComponent<GameObject>();
        acceptButton = GameObject.Find("AcceptButton");
        acceptButton.SetActive(true);

    }
    public void HideHaggleButton()
    {
        haggleButton = haggleButton.GetComponent<GameObject>();
        haggleButton = GameObject.Find("HaggleButton");
        haggleButton.SetActive(false);

    }
    public void HideAcceptButton()
    {
        acceptButton = acceptButton.GetComponent<GameObject>();
        acceptButton = GameObject.Find("AcceptButton");
        acceptButton.SetActive(false);

    }

    public void ActivateDialoguePanel()
    {
        Panel = Panel.GetComponent<GameObject>();
        Panel.SetActive(true);
    }
}
