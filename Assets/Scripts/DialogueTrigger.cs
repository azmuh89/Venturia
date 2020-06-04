﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public string npcName;
    [TextArea(3, 10)]
    public string[] sentences;
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;

    private Transform player;
    private int currentSentence = 0;
    private bool inTalkRange = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (inTalkRange && Input.GetKeyDown(KeyCode.Space))
        {
            StartDialogue();
            currentSentence++;
            EndDialogue();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        inTalkRange = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        inTalkRange = false;
    }

    void StartDialogue()
    {
        dialogueBox.SetActive(true);
        Time.timeScale = 0;
        nameText.text = npcName;

        StartCoroutine("TypeSentence");
    }

    IEnumerator TypeSentence()
    {
        dialogueText.text = "";

        if (currentSentence < sentences.Length)
        {
            foreach (char letter in sentences[currentSentence].ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
        }
    }

    void EndDialogue()
    {
        if (currentSentence >  sentences.Length)
        {
            dialogueBox.SetActive(false);
            Time.timeScale = 1;
            currentSentence = 0;
        }
    }
}
