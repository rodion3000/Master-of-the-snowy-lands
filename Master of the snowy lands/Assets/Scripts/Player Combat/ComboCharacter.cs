using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCharacter : MonoBehaviour
{

    private StateMachine meleeStateMachine;


    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private int attackDamage = 40;
    // [SerializeField] private float attackRate = 2f;
    [SerializeField] private LayerMask enemyBlock;
    [SerializeField] private Animator animator;
    private float timeBlock;
    private Rigidbody2D rb;
    public AudioClip[] soundWeapon;

    // Start is called before the first frame update
    void Start()
    {
        meleeStateMachine = GetComponent<StateMachine>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {         
             meleeStateMachine.SetNextState(new MeleeEntryState());
        }
        if (Time.time >= timeBlock)
        {
            if (Input.GetMouseButtonDown(1))
            {
                animator.SetTrigger("Block");
                timeBlock = Time.time + 0.55f;
            }
            
        }
    }

    public void Attack()
    {
        
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyTakeDamage>().TakeDamage(attackDamage);
            }
            Collider2D[] blockEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyBlock);
            foreach (Collider2D enemy in blockEnemies)
            {
               enemy.GetComponent<EnemyTakeDamage>().TakeBlock();
           }


    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

    private IEnumerator Block()
    {
        animator.SetTrigger("Block");
        yield return new WaitForSeconds(2f);
    }


}
