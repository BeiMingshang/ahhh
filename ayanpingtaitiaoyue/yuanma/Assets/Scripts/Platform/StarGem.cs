using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGem : MonoBehaviour
{
    [SerializeField] float resetTime = 3.0f;
    [SerializeField] AudioClip pickUpSFX;
    [SerializeField] ParticleSystem pickUpVfX;
    MeshRenderer meshRenderer;
    new Collider collider;
    WaitForSeconds waidResetTime;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        collider = GetComponent<Collider>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        waidResetTime = new WaitForSeconds(resetTime);
    }
    void OnTriggerEnter(Collider other)
    {
  
        if(other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.CanAirJump = true;
            meshRenderer.enabled = false;
            collider.enabled = false;
            SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);
            //audioSource.PlayOneShot(pickUpSFX);
            Instantiate(pickUpVfX,transform.position,transform.rotation);
            // Invoke("Reset", resetTime);
            StartCoroutine(ResetCoroutine());
        }

    }
    private void Reset()
    {
        meshRenderer.enabled = true;
        collider.enabled =true;

    }
    IEnumerator ResetCoroutine()
    {
        yield return waidResetTime;
        Reset();
    }
}
