using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine :StateMachine 
{
   
    [SerializeField] PlayerState[] states;

    Animator animator;
    PlayerInput input;
    PlayerController player;
    void Awake()
    {
       animator = GetComponentInChildren<Animator>();

       input = GetComponent<PlayerInput>();

       player=GetComponent<PlayerController>();

       stateTable=new Dictionary<System.Type, IState>(states.Length);

        foreach (var state in states)
        {
            state.Initialize(animator,player,input, this);  
            stateTable.Add(state.GetType(), state);
        }
    }
    void Start()
    {
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);       
    }
}
