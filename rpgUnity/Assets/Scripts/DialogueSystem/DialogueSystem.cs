using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    //Patron de diseño singleton
    public static DialogueSystem Instance { get; set; }

    // Variables del singleton
    public GameObject dialoguePanel;
    
    public List<string> dialogueLines = new List<string>();
    public string npcName;

    Button continueButton;
    TextMeshProUGUI dialogueText, nameText;
    int dialogueIndex;

    private void Awake()
    {
        // Codigo obsoleto
        //continueButton = dialoguePanel.transform.FindChild("Continue").GetComponent<Button>();
        //dialogueText = dialoguePanel.transform.FindChild("Text").GetComponent<Text>();
        //nameText = dialoguePanel.transform.FindChild("Name").GetChild(0).GetComponent<Text>();

        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<TextMeshProUGUI>();

        continueButton.onClick.AddListener(delegate { continueDialogue(); });
        dialoguePanel.SetActive(false);

        //Metodo singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void addNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;

        Debug.Log(npcName);

        createDialogue();

    }

    public void createDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void continueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        } else
        {
            dialoguePanel.SetActive(false);
        }
    }

}
