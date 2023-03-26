using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField] float detectionRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;
    Collider[]colliders=new Collider[1];
    public bool IsGrounded=> Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, colliders, groundLayer) != 0;
    private void OnDrawGizmosSelected()//�жϼ�ⷶΧ
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
