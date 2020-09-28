﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interaction : MonoBehaviour
{
    public Dialogue dialogue;
    public TextMeshProUGUI dialogueField;
    public Animator animator;
    public Animator animator2;
    public float typingDelay = 0f;

    private Queue<string> sentences;
    private bool inRange = false;

    [System.Serializable]
    public class Dialogue
    {
        public string name;
        [TextArea(3, 10)]
        public string[] sentences;
    }

    private void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E)) DisplayNextDialogue(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().isReading = true;
            collision.GetComponent<PlayerController>().leftrightcontext = 0;
            collision.GetComponent<PlayerController>().updowncontext = 0;
            StartDialogue(collision);
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EndDialogue(collision);
            inRange = false;            
        }
    }

    public void StartDialogue(Collider2D collision)
    {
        animator.SetBool("isOpen", true);
        animator2.SetBool("isOpen", true);

        sentences.Clear();

        foreach (string s in dialogue.sentences)
        {
            sentences.Enqueue(s);
        }

        DisplayNextDialogue(collision);
    }

    public void DisplayNextDialogue(Collider2D collision)
    {
        if (sentences.Count == 0)
        {
            EndDialogue(collision);
            return;
        }
        StopAllCoroutines();
        StartCoroutine(TypeDialog(sentences.Dequeue()));
    }

    IEnumerator TypeDialog(string sentence)
    {
        dialogueField.SetText("");
        foreach (char c in sentence.ToCharArray())
        {
            dialogueField.text += c;
            yield return new WaitForSeconds(typingDelay);
        }
    }

    public void EndDialogue(Collider2D collision)
    {
        collision.GetComponent<PlayerController>().isReading = false;
        GetComponent<Collider2D>().enabled = false;
        StopAllCoroutines();        
        dialogueField.SetText("");
        animator.SetBool("isOpen", false);
        animator2.SetBool("isOpen", false);        
    }
}
