using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] Vector3 rotation;

    private void Update()//��ת��ʯ
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
