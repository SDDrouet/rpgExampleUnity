using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    // Definimos las estadisticas del item y su nombre
    public List<BaseStat> stats {  get; set; }
    public string objectSlug { get; set; }

    //Constructor
    public Item(List<BaseStat> stats, string objectSlug)
    {
        this.stats = stats;
        this.objectSlug = objectSlug;
    }
}
