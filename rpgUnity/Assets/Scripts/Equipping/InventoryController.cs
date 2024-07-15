using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{    
    // obtenemos el controlador de armas del jugador
    // Nos sirve para interactuar entre lo que tiene el jugador y lo que esta en el inventario
    public PlayerWeaponController playerWeaponController;

    // Definimos un inventario echo en el codigo
    // Equipamos una espada en el inventario
    public Item sword;

    private void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();

        // Creamos una espada con un stat, sword es de tipo Item
        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(6, "Power", "Power Level level."));
        sword = new Item(swordStats, "sword");
    }

    private void Update()
    {
        //Probamos que al presionar V la espada se equipo, simulando el inventario
        if (Input.GetKeyUp(KeyCode.V)) {
            playerWeaponController.equipWeapon(sword);
        }
    }
}
