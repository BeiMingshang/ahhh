using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] VoidEventChannel gateTriggeredEventChannel;
    [SerializeField] AudioClip pickUpSFX;
    [SerializeField] ParticleSystem pickUpVFX;
   // public  event System.Action Delegate;
    private void OnTriggerEnter(Collider other)
    {
        //Delegate?.Invoke();
        gateTriggeredEventChannel.Broadcast();
        SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);
        Instantiate(pickUpVFX,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
