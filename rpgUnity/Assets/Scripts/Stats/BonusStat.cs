using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusStat
{
    // Calculamos solo el valor de una estadistica adicional
    public int bonusValue { get; set; }

    public BonusStat(int bonusValue)
    {
        this.bonusValue = bonusValue;
        Debug.Log("new stat bonus initiated");
    }
}
