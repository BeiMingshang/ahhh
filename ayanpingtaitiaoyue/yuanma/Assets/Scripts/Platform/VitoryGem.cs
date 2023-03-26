using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitoryGem : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearedEventChannel;
    [SerializeField] AudioClip pickUpSFX;
    [SerializeField] ParticleSystem pickUpVFX;
    private void OnTriggerEnter(Collider other)
    {
        levelClearedEventChannel.Broadcast();
        SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);
        Instantiate(pickUpVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
