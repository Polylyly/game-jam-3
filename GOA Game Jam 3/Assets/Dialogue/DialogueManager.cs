using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject Panel;
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public static DialogueManager instance;

    private GameObject FirstBigoton;

    private void Awake()
    {
        instance = this;
    }

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        Panel.SetActive(true);
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("started conversation, loaded mesages: " + messages.Length);
        DisplayMessage();
    }
    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }
    public void NextMessage()
    {
        Panel = Panel.GetComponent<GameObject>();

        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {

            Debug.Log("first conversation ended");
            Panel.SetActive(false);
            if (actorName.text == "El Bigoton") 
            {
                Debug.Log("convo ended w el B");
                BigotonScript.instance.ActivateBigoton();
                FirstBigoton = GameObject.Find("BigotonNPC");
                FirstBigoton.SetActive(false);
            }
            if (actorName.text == "Bella")
            {
                Debug.Log("convo ended w Bella"); 
                GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.GetComponent<MetalDetectorBehavior>().Charge(100f);
            }
            //gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Panel = Panel.GetComponent<GameObject>();
        Panel.SetActive(false);
    }

    public void ActivateDialoguePanel()
    {
        Panel = Panel.GetComponent<GameObject>();
        Panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isActive == true)
        {
            NextMessage();
        }
    }
}
