using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;
    public string npcName;

    public override void interact()
    {
        DialogueSystem.Instance.addNewDialogue(dialogue, npcName);
        Debug.Log("Interactuando con el NPC");
    }
}
