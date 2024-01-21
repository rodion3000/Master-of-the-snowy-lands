
using UnityEngine;

public class Enemy_SkeletonShield : EnemyTakeDamage
{
    public AudioClip soundBlock;
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        PlayerRPG.AdjustExperience(200);
        base.Die();
    }

    public override void TakeBlock()
    {
        enemyAudio.PlayOneShot(soundBlock);
        base.TakeBlock();
    }
}

 

