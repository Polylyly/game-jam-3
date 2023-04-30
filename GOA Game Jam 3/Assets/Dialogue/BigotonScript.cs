using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigotonScript : MonoBehaviour
{
    public GameObject FunctionalBigoton;
    private GameObject Panel;
    private Image actorImage;
    private Text actorName;
    private Text dialgueText;
    //public RectTransform backgroundBox;

    public string firstMsg;
    public string goodbyeMsg;
    public string losingGoodbyeMsg;
    public string cancelMsg;
    public string optionMsg;

    public static BigotonScript instance;
    private DialogueTriggering dialogueInstance;
    private void Awake()
    {
        instance = this;
        DialogueTriggering dialogueInstance = GetComponent<DialogueTriggering>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Panel = dialogueInstance.dialogeBox;
        actorName.text = dialogueInstance.name;
        actorImage.sprite = dialogueInstance.avatarr;

        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    // public void ActivateBigoton()
    // {

    //     FunctionalBigoton = FunctionalBigoton.GetComponent<GameObject>();
    //     FunctionalBigoton.SetActive(true);
    // }

    public void StateValue(int x)
    {
        GameObject.Find("BigotonDialogue/DialogueBox/Message").GetComponent<UnityEngine.UI.Text>().text = "I can give you " + x + " for that; pretty reasonable, eh?";
    }

    public void PlayFirstMsg()
    {
        GameObject.Find("BigotonDialogue/DialogueBox/Message").GetComponent<UnityEngine.UI.Text>().text = firstMsg;
    }

    public void PlayCancelMsg()
    {
        GameObject.Find("BigotonDialogue/DialogueBox/Message").GetComponent<UnityEngine.UI.Text>().text = cancelMsg;
    }
    public void PlayOptionMsg()
    {
        GameObject.Find("BigotonDialogue/DialogueBox/Message").GetComponent<UnityEngine.UI.Text>().text = optionMsg;
    }
    public void PlayGoodbyeMsg()
    {
        GameObject.Find("BigotonDialogue/DialogueBox/Message").GetComponent<UnityEngine.UI.Text>().text = goodbyeMsg;
    }
    public void PlayLosingGoodbyeMsg()
    {
        GameObject.Find("BigotonDialogue/DialogueBox/Message").GetComponent<UnityEngine.UI.Text>().text = losingGoodbyeMsg;
    }

    public void ActivateDialoguePanel()
    {
        Panel = dialogueInstance.dialogeBox;
        Panel.SetActive(true);
    }
}
