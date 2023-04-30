// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DialogueTrigger : MonoBehaviour
// {
//     public Message[] messages;
//     public Actor[] actors;

//     public static DialogueTrigger instance;
//     private void Awake()
//     {
//         instance = this;
//     }

//     public void StartDialogue()
//     {
//         DialogueManager.instance.ActivateDialoguePanel();
//         FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
//     }
// }

// [System.Serializable]
// public class Message 
// {
//     public int actorID;
//     public string message;
// }

// [System.Serializable]
// public class Actor
// {
//     /*
//     Local/Tito is 0
//     Haggler/Bigoton is 1
//     Vendor/Bella is 2
//     */
//     public string name;
//     public Sprite sprite;
// }
