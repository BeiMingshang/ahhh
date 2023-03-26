using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour//��Ծ���ָ��Ż�����û��
{
    [SerializeField] float jumpInputBufferTime=0.5f;
    WaitForSeconds waitJumpInputBufferTime;
    PlayerInputActions playerInputActions;
    Vector2 axes => playerInputActions.Gameplay.Axes.ReadValue<Vector2>();
    public bool Jump => playerInputActions.Gameplay.Jump.WasPressedThisFrame();
    public bool StopJump =>playerInputActions.Gameplay.Jump.WasReleasedThisFrame();
    public bool Move => AxisX != 0f;
    public bool HasJumpInputBuffer { get; set; }
    public float  AxisX=>axes.x;//ȡ�õ�ֵֻ��0��-1��1
    
     void Awake()
    {
        playerInputActions=new PlayerInputActions();
        waitJumpInputBufferTime=new WaitForSeconds(jumpInputBufferTime);
    }
    private void OnEnable()
    {
        playerInputActions.Gameplay.Jump.canceled += delegate
        {
            HasJumpInputBuffer = false;
        };
    }
    //private void OnGUI()
    //{
    //    Rect rect = new Rect(200, 200, 200, 200);
    //    string message = "Has Jump Input Buffer" + HasJumpInputBuffer;
    //    GUIStyle style=new GUIStyle();
    //    style.fontSize = 20;
    //    style.fontStyle = FontStyle.Bold;
    //    GUI.Label(rect, message, style);
    //}
    public void EnableGameplayInputs()
    {
        playerInputActions.Gameplay.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void DisableGameplayInouts()
    {
        playerInputActions.Gameplay.Disable();
    }
    public void SetJumpInputBufferTimer()
    {
        StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }
    IEnumerator JumpInputBufferCoroutine()//��δ�����һ��Э�̣�������һ��ʱ���HasJumpInputBuffer����Ϊfalse�����˻�ûѧϰ
    {
        HasJumpInputBuffer = true;
        yield return waitJumpInputBufferTime;
        HasJumpInputBuffer=false;
    }

    
}
