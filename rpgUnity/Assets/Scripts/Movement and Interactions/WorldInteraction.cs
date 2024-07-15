using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour
{
    NavMeshAgent playerAgent;

    void GetInteraction()
    {
        // Funcion para lanzar un rayo desde el puntero del mouse
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        //Verificamos si se puede extraer informacion del objeto dado
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            //Obtenemos el objeto
            GameObject interactedObject = interactionInfo.collider.gameObject;

            // Si el objeto tiene el tag entonces seguimos con el objeto si no realizamos la acción de movieminto
            if (interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().moveToInteraction(playerAgent);
            }
            else
            {
                playerAgent.stoppingDistance = 0f;
                // Moverse a la posicion del mouse
                playerAgent.destination = interactionInfo.point;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
             GetInteraction();
        }
    }
}
