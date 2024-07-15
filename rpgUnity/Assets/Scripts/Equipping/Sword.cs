using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;
    //Las estadisticas adicionales para esta arma sword
    public List<BaseStat> stats { get; set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    //Implementamos un ataque para el arma
    public void performAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    public void performSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
    }
}
