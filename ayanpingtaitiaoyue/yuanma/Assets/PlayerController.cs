using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //    Animator animator;
    //    void Awake()
    //    {
    //        animator = GetComponentInChildren<Animator>();
    //    }
    //    void Update()
    //    {
    //        if (Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed)
    //        {
    //            animator.Play("Run");
    //        }
    //        else
    //        {
    //            animator.Play("Idle");
    //        }
    //    }
    PlayerGroundDetector groundDetector;
    PlayerInput input;
    Rigidbody rigidBody;
    [SerializeField] VoidEventChannel levelClearedEventChannel;
    public AudioSource VoicePlayer {  get; private set; }
    public bool CanAirJump { get; set; }

    public bool Victory { get; set; }
    public bool IsGrounded=> groundDetector.IsGrounded;
    public bool IsFalling => rigidBody.velocity.y < 0f && !IsGrounded;
    
    public float MoveSpeed =>Mathf.Abs( rigidBody.velocity.x);//后面用于减速，加速
    
    private void Awake()
    {
        groundDetector = GetComponentInChildren<PlayerGroundDetector>();
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody>();
        VoicePlayer=GetComponentInChildren<AudioSource>();
        
    }
    private void OnEnable()
    {
        levelClearedEventChannel.AddListener(OnLevelCleared);
    }
    private void OnDisable()
    {
        levelClearedEventChannel.RemoveListener(OnLevelCleared);
    }
    private void OnLevelCleared()
    {
        Victory = true;
    }

    private void Start()
    {
        input.EnableGameplayInputs();
    }
    public void Move(float speed)
    {
        if (input.Move)//用于转向
        {
            transform.localScale = new Vector3(input.AxisX, 1f, 1f);
        }
        SetVelocityX(speed*input.AxisX);

    }
    public void SetVelocity(Vector3 velocity)
    {
        rigidBody.velocity = velocity;  
    }
    public void SetVelocityX(float velocityX)
    {
        rigidBody.velocity=new Vector3(velocityX,rigidBody.velocity.y);

    }
    public void SetVelocityY(float velocityY)
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, velocityY);

    }
    public void SetUseGravity(bool value)
    {
        rigidBody.useGravity = value;
    }

    public void OnDefeadted()
    {
        input.DisableGameplayInouts();
        rigidBody.velocity = Vector3.zero;
        rigidBody.useGravity=false;
        rigidBody.detectCollisions = false;
        GetComponent<StateMachine>().SwitchState(typeof(PlayerState_Defeated));

    }
}
