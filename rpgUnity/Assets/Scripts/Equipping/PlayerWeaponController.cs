using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    // Definimos cual es la mano del player, donde aparecera el arma
    public GameObject playerHand;

    // Definimos un arma equipada en la mano
    public GameObject equippedWeapon { get; set; }

    // Arma la cual implementa un IWeapon
    IWeapon weapon;
    CharacterStats characterStats;

    private void Start()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    public void equipWeapon(Item itemToEquip)
    {
        if (equippedWeapon != null)
        {
            characterStats.RemoveStatBonus(equippedWeapon.GetComponent<IWeapon>().stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }


        // Obtenemos el arma de los prefabs en resources, el cual esta en la carpeta Weapons
        // y establecemos la posicion y rotación de la mano
        equippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.objectSlug),
            playerHand.transform.position, playerHand.transform.rotation);

        //Obtenemos el componente que hace referencia al script IWeapon del equipedWeapon
        weapon = equippedWeapon.GetComponent<IWeapon>();

        // Configuramos las estadisticas del arma equipada
        weapon.stats = itemToEquip.stats;

        // Colocamos la arma que creamos en la mano para que esta sea su objeto padre
        equippedWeapon.transform.SetParent(playerHand.transform);

        // Establecemos la escala original
        equippedWeapon.transform.localScale = Vector3.one;

        //Agregamos las estadisticas al personaje
        characterStats.AddStatBonus(itemToEquip.stats);

        Debug.Log("demage " + itemToEquip.objectSlug + ": " + itemToEquip.stats[0].getCalculatedStatValue());
        Debug.Log("character Stat " + characterStats.stats[0].statName + ": " + characterStats.stats[0].getCalculatedStatValue());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            performWeaponAttack();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            performWeaponSpecialAttack();
        }
    }

    //Realizar ataque con la arma
    public void performWeaponAttack()
    {
        weapon.performAttack();
    }

    public void performWeaponSpecialAttack()
    {
        weapon.performSpecialAttack();
    }
}
