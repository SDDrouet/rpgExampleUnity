using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem
{
    public override void interact()
    {
        base.interact();
        Debug.Log("Interacting with sign post");
    }
}
