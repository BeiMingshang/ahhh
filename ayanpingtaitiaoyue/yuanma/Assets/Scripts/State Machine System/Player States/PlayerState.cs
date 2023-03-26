using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState :ScriptableObject,IState
{
    [SerializeField] string stateName;
    [SerializeField,Range(0f,1f)] float transitionDuration = 0.1f;
    int stateHash;
    float stateStartTime;
    protected Animator animator;
    protected PlayerInput input;
    protected PlayerStateMachine stateMachine;
    protected PlayerController player;
    
    protected float currentSpeed;
    protected float StateDuration=>Time.time-stateStartTime;
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;//0代表当前动画
    private void OnEnable()
    {
        stateHash=Animator.StringToHash(stateName);
    }

    public void Initialize(Animator animator,PlayerController player, PlayerInput input,PlayerStateMachine stateMachine)
    {
       this.player = player;
        this.input = input;
        this.animator = animator;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter()
    {
        stateStartTime=Time.time;
        animator.CrossFade(stateHash, transitionDuration);
    }

    public virtual void Exit()
    {
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicUpdate()
    {

    }
}
