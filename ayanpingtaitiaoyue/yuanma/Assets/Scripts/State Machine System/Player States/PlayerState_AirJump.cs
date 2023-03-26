using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Date/StateMachine/PlayerState/AirJump",fileName ="PlayerState_AirJump")]

public class PlayerState_AirJump : PlayerState
{
    [SerializeField] ParticleSystem jumpVFX;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] AudioClip jumpSFX;
    public override void Enter()
    {
        base.Enter();
        player.CanAirJump = false;
        player.SetVelocityY(jumpForce);
        player.VoicePlayer.PlayOneShot(jumpSFX);
        Instantiate(jumpVFX,player.transform.position,Quaternion.identity);
    }

    public override void LogicUpdate()
    {
        if (input.StopJump || player.IsFalling)
        {
            stateMachine.SwitchState(typeof(PlayeState_Fall));
        }
    }

    public override void PhysicUpdate()
    {
        player.Move(moveSpeed);

    }
}
