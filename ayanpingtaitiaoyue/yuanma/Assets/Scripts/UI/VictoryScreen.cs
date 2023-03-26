using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearedEventChannel;
    [SerializeField] Button nextLevelButton;
    [SerializeField] Text timeText;
    [SerializeField] StringEventChannel clearTimeTextEventChannel;
    private void OnEnable()
    {
        levelClearedEventChannel.AddListener(showUI);
        clearTimeTextEventChannel.AddListener(SetTimeText);
        nextLevelButton.onClick.AddListener(SceneLoader.LoadNextScene);
    }
    private void OnDisable()
    {
        clearTimeTextEventChannel.RemoveListener(SetTimeText);
        levelClearedEventChannel.RemoveListener(showUI);
        nextLevelButton.onClick.RemoveListener(SceneLoader.LoadNextScene);
    }
    private void showUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
    }
    void SetTimeText(string text)
    {
        timeText.text = text;
    }
}
