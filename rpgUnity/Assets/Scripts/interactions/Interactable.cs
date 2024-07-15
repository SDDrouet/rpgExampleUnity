using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent playerAgent;
    private bool hasInteracted;

    private void Update()
    {
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void moveToInteraction(NavMeshAgent playerAgent)
    {        
        // Como los objetos o npc no son parte del navmesh cuando se hace clic en ellos el player no se movera a esa posicion
        // Para ello obtenemos la información de estos y navegamos a donde se encuentran
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        playerAgent.destination = this.transform.position;
    }

    public virtual void interact()
    {
        Debug.Log("Interactuando con la clase base");
    }
}
