using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Son las estadisticas base del personaje este objeto lo colocamos dentro del personaje
    public List<BaseStat> stats = new List<BaseStat>();

    private void Start()
    {
        //Estadisticas base del personaje 2 de vida y 4 de poder
        stats.Add(new BaseStat(4, "Power", "Power level."));
        stats.Add(new BaseStat(2, "Vitality", "Vitality Level."));        
    }

    // Funcion para añadir estadisticas cuando equipamos un objeto al personaje
    public void AddStatBonus(List<BaseStat> bonusStats)
    {
        foreach (BaseStat stat in bonusStats)
        {
            stats.Find(x => x.statName == stat.statName).addStatBonus(new BonusStat(stat.baseValue));
        }
    }

    // Funcion para remover estadisticas cuando desequipamos un objeto al personaje
    public void RemoveStatBonus(List<BaseStat> bonusStats)
    {
        foreach (BaseStat stat in bonusStats)
        {
            stats.Find(x => x.statName == stat.statName).removeBonusStat(new BonusStat(stat.baseValue));
        }
    }
}
