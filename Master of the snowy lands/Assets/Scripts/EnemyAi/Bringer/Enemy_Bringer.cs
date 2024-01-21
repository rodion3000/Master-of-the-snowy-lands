using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bringer : EnemyTakeDamage
{
    
    public override void TakeDamage(int damage)
    {
       animator.SetTrigger("Hurt");
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        PlayerRPG.AdjustExperience(500);
        PlayerRPG.AdjustCurrentValue(5, PlayerAttribute.Agility);
        base.Die();
    }
}
