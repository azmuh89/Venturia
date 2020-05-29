using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
