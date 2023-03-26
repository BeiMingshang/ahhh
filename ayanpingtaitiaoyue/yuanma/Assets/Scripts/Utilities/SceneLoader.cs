
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader //没懂
{
    public static void ReloadScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
    public static void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//退出动画播放器
#else
        Application.Quit();
#endif
        /// <summary>
        /// 这种写法是 C# 中的条件编译指令。
        /// #if UNITY_EDITOR 表示如果当前编译环境是 Unity 编辑器，则编译 UnityEditor.EditorApplication.isPlaying = false;
        /// 这一行代码，否则编译 Application.Quit(); 这一行代码
        ///</summary>
    }

    public static void LoadNextScene()
    {
        
        int sceneIndex = SceneManager.GetActiveScene().buildIndex+1;
        if (sceneIndex>=SceneManager.sceneCount)
        {
            ReloadScene();
            return;
        }
            SceneManager.LoadScene(sceneIndex);
    }
}
