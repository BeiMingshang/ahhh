using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackball : MonoBehaviour
{
    [SerializeField] VoidEventChannel gateTriggerEventChannel;
    [SerializeField] float lifeTime = 10f;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            player.OnDefeadted();

        }
    }
    private void OnEnable()
    {
        gateTriggerEventChannel.AddListener(OnGateTriggered);
    }
    private void OnDisable()
    {
        gateTriggerEventChannel.RemoveListener(OnGateTriggered);
    }
    void OnGateTriggered()
    {
        Destroy(gameObject, lifeTime);
    }
}
