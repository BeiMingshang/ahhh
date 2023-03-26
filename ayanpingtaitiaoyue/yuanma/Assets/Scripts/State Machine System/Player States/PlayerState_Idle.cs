using UnityEngine;



[CreateAssetMenu (menuName = "Date/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle :PlayerState
{
    [SerializeField] float deceleration = 5f;
    public override void Enter()
    {
        
        //animator.Play("Idle");
        base.Enter();
       currentSpeed = player.MoveSpeed;//这个获取用于减速
    }
    public override void LogicUpdate()
    {
        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        if (!player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayeState_Fall));
        }
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);//用于减速
    }
    public override void PhysicUpdate()
    {
        player.SetVelocityX(currentSpeed*player.transform.localScale.x);//乘后面那个，改变速度方向
    }
}
