using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
  public static AudioSource AudioSource { get; private set; }//为什么静态更容易获取
    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.playOnAwake = false;
    }
}
