using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private SpriteRenderer sprite;
    public float DamageTimeSec = 0.5f;
    private Material attackMaterial;
    private Material defMaterial;
    protected AudioSource enemyAudio;
    public Animator animator;
    public AudioClip soundHit;
    public AudioClip soundDead;
    [SerializeField] private EnemyStateManager stateManager;
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject block;



    private void Start()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
        attackMaterial = Resources.Load("Damage", typeof(Material)) as Material;
        defMaterial = sprite.material;
        stateManager = gameObject.GetComponent<EnemyStateManager>();
        enemyAudio = GetComponent<AudioSource>();
    }
    public virtual void TakeDamage(int damage)
    {
            enemyAudio.PlayOneShot(soundHit);
            currentHealth -= damage;
            sprite.material = attackMaterial;
            var t = effect.transform.rotation;
            var s = effect.transform.rotation;
            s = Quaternion.Euler(s.x, -90f, s.z);
            if (stateManager.isFlipped == false)
            { Instantiate(effect, transform.position, t); }
            else
            { Instantiate(effect, transform.position, s); }
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                Invoke("ResetMaterial", .2f);
            }
        }
    
    public virtual void TakeBlock()
    {
        var t = block.transform.rotation;
        Instantiate(block, transform.position, t);
    }

    public virtual void Die()
    {
        enemyAudio.PlayOneShot(soundDead);
        animator.SetTrigger("IsDead");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        this.enabled = false;
        sprite.material = defMaterial;
        stateManager.enabled = false;

    }

    void ResetMaterial()
    {
        sprite.material = defMaterial;
    }


    public void StartEffect()
    {
        StopCoroutine(nameof(StartEffectCoroutine));
        StartCoroutine(nameof(StartEffectCoroutine));
    }

    private IEnumerator StartEffectCoroutine()
    {
        float time = 0;
        float step = 1f / DamageTimeSec;

        while (time < DamageTimeSec)
        {
            time += Time.deltaTime;

            yield return null;
        }
    }
}
