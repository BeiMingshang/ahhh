using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
  public static AudioSource AudioSource { get; private set; }//Ϊʲô��̬�����׻�ȡ
    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.playOnAwake = false;
    }
}
