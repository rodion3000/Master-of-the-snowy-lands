
using UnityEngine;
using UnityEngine.Playables;

public class MeleeBaseState : State
{
    // How long this state should be active for before moving on
    public float duration;
    // Cached animator component
    protected Animator animator;
    // bool to check whether or not the next attack in the sequence should be played or not
    protected bool shouldCombo;
    // The attack index in the sequence of attacks
    protected int attackIndex;
    protected bool combo = false;
    protected Rigidbody2D rb;
    protected PlayMovement playMovement;
    public ComboCharacter character;
    private AudioSource playerAudio;

    // Input buffer Timer
    private float AttackPressedTimer = 0;
   // ComboCharacter attack;

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playMovement = GetComponent<PlayMovement>();
        character = GetComponent<ComboCharacter>();
        playerAudio = GetComponent<AudioSource>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        AttackPressedTimer -= Time.deltaTime;
       
        if (Input.GetMouseButtonDown(0) == true)
        {
            AttackPressedTimer = 2;
            shouldCombo = true;
            
            
        }
        playMovement.OnLanding();

       // if (animator.GetFloat("AttackWindow.Open") > 0f && AttackPressedTimer > 0)
       // {
       //     shouldCombo = true;
      //  }
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public void ShouldCombo()
    {
        shouldCombo = true;
    }

    public void SoundAttack()
    {
        int randInd = Random.Range(0, character.soundWeapon.Length);
        playerAudio.PlayOneShot(character.soundWeapon[randInd]);
    }

}
