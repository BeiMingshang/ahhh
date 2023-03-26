using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel playerDefeatEventChannel;
    [SerializeField] AudioClip[] voice;
    [SerializeField] Button quitButton;
    [SerializeField] Button retryButton;
    private void OnEnable()
    {
        playerDefeatEventChannel.AddListener(showUI);
        retryButton.onClick.AddListener(SceneLoader.ReloadScene);
        quitButton.onClick.AddListener(SceneLoader.QuitGame);
    }
    private void OnDisable()
    {
        playerDefeatEventChannel.RemoveListener(showUI); 
        retryButton.onClick.RemoveListener(SceneLoader.ReloadScene);
        quitButton.onClick.RemoveListener(SceneLoader.QuitGame);
    }
    private void showUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;
        AudioClip retryVoice = voice[Random.Range(0,voice.Length)];
        SoundEffectsPlayer.AudioSource.PlayOneShot(retryVoice);
        Cursor.lockState = CursorLockMode.None;//œ‘ æ Û±Í
    }
}
