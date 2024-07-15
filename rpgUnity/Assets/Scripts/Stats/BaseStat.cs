using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat
{
    //Estadisticas adicionales del personaje del mismo tipo (solo se tienen el valor)
    public List<BonusStat> baseAdditivies { get; set; }

    // Estadisitca base de un objeto o personaje
    public int baseValue { get; set; }
    public string statName { get; set; }
    public string statDescription { get; set; }


    // Calculo de la estadistica final de este objeto o personaje
    public int finalValue { get; set; }

    //Constructor inicializamos la estadistica base
    public BaseStat(int baseValue, string statName, string statDescription)
    {
        this.baseAdditivies = new List<BonusStat>();
        this.baseValue = baseValue;
        this.statName = statName;
        this.statDescription = statDescription;
    }

    //Añadimos una nueva estadistica
    public void addStatBonus(BonusStat bonusStat)
    {        
        this.baseAdditivies.Add(bonusStat);
    }

    // Sacamos una estadistica
    public void removeBonusStat(BonusStat bonusStat)
    {
        this.baseAdditivies.Remove(baseAdditivies.Find(x => x.bonusValue == bonusStat.bonusValue));
    }

    // Obtenemos la estadistica final
    public int getCalculatedStatValue()
    {
        finalValue = baseValue;
        this.baseAdditivies.ForEach(x => {
            this.finalValue += x.bonusValue;
        });
        

        return finalValue;
    }
}
