using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMovie = 0f;
    private bool jump = false;
    bool crouch = false;
    public Animator animator;
    public float runStop;
    public AudioClip[] soundSteps;
    private AudioSource playerAudio;
    public AudioClip soundJump;
    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovie));
        
        horizontalMovie = Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime; 
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;          
            animator.SetBool("IsJumping", true);
            playerAudio.PlayOneShot(soundJump);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMovie, crouch, jump);
        jump = false;
        
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }

    public void SoundStep()
    {
        int randInd = Random.Range(0, soundSteps.Length);
        playerAudio.PlayOneShot(soundSteps[randInd]);
    }
    
}
