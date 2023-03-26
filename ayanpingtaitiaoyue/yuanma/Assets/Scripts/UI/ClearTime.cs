using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTime : MonoBehaviour//计时器功能
{
    [SerializeField] Text timeText;
    [SerializeField] VoidEventChannel levelStartedEventChannel;
    [SerializeField] VoidEventChannel levelClearedEventChannel;
    [SerializeField] StringEventChannel clearTimeTextEventChannel;
    [SerializeField] VoidEventChannel playerDefeatedEventChannel;
    float clearTime;
    bool stop = true;

    private void OnEnable()
    {
        levelStartedEventChannel.AddListener(LevelStart);
        levelClearedEventChannel.AddListener(LevelClear);
        playerDefeatedEventChannel.AddListener(HideUI);
    }

    private void LevelClear()
    {
        HideUI();
        clearTimeTextEventChannel.Broadcast(timeText.text);
    }

    private void LevelStart()
    {
        stop = false;
    }
     
    private void HideUI()
    {
        stop=true;
        GetComponent<Canvas>().enabled = false;
    }

    private void OnDisable()
    {
        levelStartedEventChannel.RemoveListener(LevelStart);
        levelClearedEventChannel.RemoveListener(LevelClear);
        playerDefeatedEventChannel.RemoveListener(HideUI);
    }
    private void FixedUpdate()
    {
        if (stop) return;
        clearTime += Time.fixedDeltaTime;
        timeText.text = System.TimeSpan.FromSeconds(clearTime).ToString(@"mm\:ss\:ff");
    }
}
