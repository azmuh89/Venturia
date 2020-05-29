using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialogueBox;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }
    
    void Update()
    {
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with: " + dialogue.name);

        DialogueBox.SetActive(true);
    }
}
