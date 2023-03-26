

using UnityEngine;


[CreateAssetMenu(menuName = "Date/StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]

public class PlayerState_Run : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceleration = 5f;
    public override void Enter()
    {
        //animator.Play("Run");
        base.Enter();

        currentSpeed = player.MoveSpeed;//用于加速
        
    }
    public override void LogicUpdate()
    {

        if(! input.Move)
        {
           // player.SetVelocityX(0f);
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        if(!player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerState_CoyoteTime));  
        }
        currentSpeed =Mathf.MoveTowards(currentSpeed, runSpeed,acceleration*Time.deltaTime );
    }
    public override void PhysicUpdate()
    {
        player.Move(currentSpeed);
        
    }
}
