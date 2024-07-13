using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    //Patron de diseño singleton
    public static DialogueSystem Instance { get; set; }

    // Variables del singleton
    public List<string> dialogueLines = new List<string>();
    public string npcName;


    private void Awake()
    {
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
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);

        Debug.Log(dialogueLines.Count);

    }


}
