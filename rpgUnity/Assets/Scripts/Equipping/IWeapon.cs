using System.Collections.Generic;

public interface IWeapon
{
    // Esta es la base de cualquier arma la cual debe ser implementada

    // Estadisticas base del arma
    public List<BaseStat> stats { get; set; }
    //Funcion definida para hcaer ataques
    void performAttack();
    void performSpecialAttack();
}
