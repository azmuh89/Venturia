using System.Collections;
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

    private GameObject player;
    private int currentSentence = 0;
    private bool inTalkRange = false;
    private bool dialogueStarted = false;
    private bool sentenceFinished = false;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inTalkRange && !dialogueStarted)
        {
            StartDialogue();
        }

        if (Input.GetKeyDown(KeyCode.Space) && sentenceFinished)
        {
            sentenceFinished = false;
            StartCoroutine("TypeSentence");
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
        dialogueStarted = true;
        dialogueBox.SetActive(true);
        player.GetComponent<Animator>().SetFloat("Speed", 0);
        player.GetComponent<PlayerController>().enabled = false;
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
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    dialogueText.text += letter;
                    yield return new WaitForEndOfFrame();
                }
                else
                {
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.005f);
                }
            }

            currentSentence++;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                StartCoroutine("TypeSentence");
            }
            else
            {
                sentenceFinished = true;
            }
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueStarted = false;
        dialogueBox.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;
        currentSentence = 0;
    }
}
