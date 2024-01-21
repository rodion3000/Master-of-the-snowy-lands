using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class PlayerHealth : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin channelPerlin;
    private float shakeIntensity = 1f;
    private float shakeTime = 0.2f;
    private float timer;

    public Animator animator;
    public int maxHealth;
    public HealthBar healthBar;
    public AudioClip soundHit;
    public AudioClip soundBlock;
    public AudioClip soundDead;
    private int currentHealth;
    private AudioSource playerAudio;
    [SerializeField] private Behaviour entity;
    [SerializeField] private Behaviour weapon;
    // [SerializeField] private GameObject effect;
    [SerializeField] private GameObject block;
    
    private void Awake()
    {
        PlayerRPG.OnExperience += LvlUpHealth;
    }
    private void Start()
    {
       // StopShake();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerAudio = GetComponent<AudioSource>();
    }

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin ChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        channelPerlin.m_AmplitudeGain = shakeIntensity;
        timer = shakeTime;
        if(timer > 0)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                StopShake();
            }
        }
    }

    private void StopShake()
    {
        CinemachineBasicMultiChannelPerlin ChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        channelPerlin.m_AmplitudeGain = 0;
        timer = 0;
    }

    public void TakeDamage(int damage)
    {
       // ShakeCamera();
        currentHealth -= damage;
        animator.SetTrigger("Hit");
        healthBar.SetHealth(currentHealth);
        playerAudio.PlayOneShot(soundHit);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeBlock()
    {
        var t = block.transform.rotation;
        Instantiate(block, transform.position, t);
        playerAudio.PlayOneShot(soundBlock);
    }

    void Die()
    {
        // animator.SetBool("Death", true);
       // animator.SetTrigger("IsDead");
        playerAudio.PlayOneShot(soundDead);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        entity.enabled = false;
        weapon.enabled = false;
        animator.SetTrigger("IsDead");



    }
    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0;i<3;i++)
        {
            foreach(SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }
            yield return new WaitForSeconds(.1f);
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }
            yield return new WaitForSeconds(.1f);
        }
    }

    public void LvlUpHealth()
    {
        maxHealth += 10;
    }
    
}
