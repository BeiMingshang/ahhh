using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyScreen : MonoBehaviour
{
    [SerializeField] AudioClip startVoice;
    [SerializeField] VoidEventChannel levelStartedEventChannel;
    void LevelStart()
    {
        levelStartedEventChannel.Broadcast();
        GetComponent<Canvas>().enabled = false;
        GetComponent<Animator>().enabled = false;//½ûÓÃ¶¯»­²¥·Å
    }
    void PlayStartVoice()
    {
        SoundEffectsPlayer.AudioSource.PlayOneShot(startVoice);
    }
}
