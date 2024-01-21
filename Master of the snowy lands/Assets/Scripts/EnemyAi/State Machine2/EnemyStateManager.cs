using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class EnemyStateManager : MonoBehaviour
{
    [Header("Enemy Controll")]
    public bool idleEnemy = false;
    public bool patrolEnemy = false;
    public bool pillarEnemy = false;
    public Animator animator;
    public Transform player;
    public bool isFlipped = false;
    public Rigidbody2D rb;
    public float speedRun;
    public Transform stopRunCollider;
    public float stopRange;
    public LayerMask tileLayer;
    public bool lookAt = true;
    public AudioClip soundRun;
    private AudioSource enemyAudio;

    [Header ("Enemy Attack")]
    public float attackDistance = 1.2f;
    public float agroDistance = 4.5f;
    public AudioClip attackSound;
    private float agroDistanceOut;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private float attackRange2 = 0.5f;
    public LayerMask playerLayers;
    [SerializeField] private Rigidbody2D playerRigibody;
    [SerializeField] private int attackDamage = 40;
   // [SerializeField] private float attackRate = 2f;
    [SerializeField] private Transform attackPoint1;
    [SerializeField] private Transform attackPoint2;
    public Transform touchPoint;
    public float touchPointRange;
    [SerializeField] private LayerMask playerBlock;
    

    [Header("Enemy Patrol")]
    public Transform[] moveSpots;
    public float startWaitTime;
  

    EnemyFundamentState currentState;
    public PatrolEn patrol = new PatrolEn();
    public PillarEn pillar = new PillarEn();
    public  RunEn run = new RunEn();
    public IdleEn idle = new IdleEn();
    public ChoiceEn choice = new ChoiceEn();
    public AttackEn attacked = new AttackEn();

    private void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
    currentState = choice;
        currentState.EnterState(this);
    }
    

    private void Update()
    {
        currentState.UpdaterState(this);

    }

   public void SwitchState(EnemyFundamentState state)
    {
        currentState=state;
        state.EnterState(this);
    }

    private void FixedUpdate()
    {
        currentState.FixUpdaterState(this);
    }

    public void Attack()
    {

        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint1.position, attackRange, playerLayers);       
            // foreach(Collider2D collider in hitPlayer)
            // {
            if (hitPlayer != null)
            {
                hitPlayer.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
            //}
            Collider2D blockPlayer = Physics2D.OverlapCircle(attackPoint1.position, attackRange, playerBlock);
            if (blockPlayer != null)
            {
                blockPlayer.GetComponent<PlayerHealth>().TakeBlock();
            
            }

        

    }

    public void Attack2()
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint2.position, attackRange2, playerLayers);      
            if (hitPlayer != null)
            {
                hitPlayer.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
        Collider2D blockPlayer = Physics2D.OverlapCircle(attackPoint2.position, attackRange2, playerBlock);
        if (blockPlayer != null)
        {
            blockPlayer.GetComponent<PlayerHealth>().TakeBlock();
        }
    }

    public void PowerAttack()
    {
        Vector3 dir = (player.transform.position - rb.transform.position).normalized;
        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint1.position, attackRange, playerLayers);
        if (hitPlayer != null)
        {
            hitPlayer.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            playerRigibody.AddForce(dir * 6f * 5f, ForceMode2D.Impulse);
        }
        Collider2D blockPlayer = Physics2D.OverlapCircle(attackPoint1.position, attackRange, playerBlock);
        if (blockPlayer != null)
        {
            blockPlayer.GetComponent<PlayerHealth>().TakeDamage(attackDamage/2);
            playerRigibody.AddForce(dir * 6f * 5f, ForceMode2D.Impulse);
        }
    }

    public void SoundRun()
    {
        enemyAudio.PlayOneShot(soundRun);
    }

    public void SoundAttack()
    {
        enemyAudio.PlayOneShot(attackSound);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange);
        Gizmos.color = Color.blue;
       Gizmos.DrawWireSphere(attackPoint2.position, attackRange2);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(stopRunCollider.position, stopRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(touchPoint.position, touchPointRange);
    }

  


}
