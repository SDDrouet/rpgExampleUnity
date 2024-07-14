using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem
{
    public string[] dialogue;
    public string signName;
    public override void interact()
    {
        DialogueSystem.Instance.addNewDialogue(dialogue, signName);
        Debug.Log("Interacting with sign post");
    }
}
