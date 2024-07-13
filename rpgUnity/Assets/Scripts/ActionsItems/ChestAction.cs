using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAction : Interactable
{
    public override void interact()
    {
        base.interact();
        Debug.Log("Interactcing with chest");
    }
}
