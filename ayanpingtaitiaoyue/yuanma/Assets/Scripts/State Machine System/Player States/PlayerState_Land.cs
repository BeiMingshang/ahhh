using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Date/StateMachine/PlayerState/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    [SerializeField] float stiffTime=0.2f;
    [SerializeField] ParticleSystem landVFX;
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(Vector3.zero);
        Instantiate(landVFX, player.transform.position, Quaternion.identity);

    }
    public override void LogicUpdate()
    {
        if(player.Victory)
        {
            stateMachine.SwitchState(typeof(PlayerState_Victory));
        }
        if (input.Jump||input.HasJumpInputBuffer)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        if (StateDuration<stiffTime)
        {
            return;
        }
        if(input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));

        }
        if(IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof (PlayerState_Idle));
        }
    }
    
}
