using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;
    protected Dictionary<System.Type, IState> stateTable;
     void Update()
    {
        currentState.LogicUpdate();
    }
    void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }
    protected void SwitchOn(IState newstate)
    {
        currentState=newstate;
        currentState.Enter();
    }
    
    public void SwitchState(IState newstate)
    {
        currentState.Exit();
        SwitchOn(newstate);
    }

    public void SwitchState(System.Type newStateType)//��newStateType��Ӧ��״̬���ֵ���ȡ����ʹ�������Switchstate�����ı�״̬
    {

        SwitchState(stateTable[newStateType]);
    }
}
