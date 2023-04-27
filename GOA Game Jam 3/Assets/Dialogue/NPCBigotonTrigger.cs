using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBigotonTrigger : MonoBehaviour

{
    //public HaggleManager trigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            Debug.Log("hit functional bigoton");

            HaggleManager.instance.StartHaggleSequence();

        }
    }
}
