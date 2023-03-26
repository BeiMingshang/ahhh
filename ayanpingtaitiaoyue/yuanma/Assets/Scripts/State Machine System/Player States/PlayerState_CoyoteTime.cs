using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Date/StateMachine/PlayerState/CoyoteTime", fileName = "PlayerState_CoyoteTime")]

public class PlayerState_CoyoteTime : PlayerState//优化手感的土狼时间
{

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float coyoteTime = 0.1f;
    public override void Enter()
    {
        //animator.Play("Run");
        base.Enter();
        player.SetUseGravity(false);
       

    }
    public override void Exit()
    {
        player.SetUseGravity(true);
    }
    public override void LogicUpdate()
    {

       
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        if (StateDuration>coyoteTime|| !input.Move)
        {
            stateMachine.SwitchState(typeof(PlayeState_Fall));
        }
        
    }
    public override void PhysicUpdate()
    {
        player.Move(runSpeed);

    }
}
