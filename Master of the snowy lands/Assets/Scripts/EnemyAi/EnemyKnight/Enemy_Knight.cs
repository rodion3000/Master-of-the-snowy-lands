using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Knight : EnemyTakeDamage
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        PlayerRPG.AdjustExperience(350);
        base.Die();
    }
}
