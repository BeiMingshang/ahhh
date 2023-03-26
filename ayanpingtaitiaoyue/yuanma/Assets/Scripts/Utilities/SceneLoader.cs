
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader //û��
{
    public static void ReloadScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
    public static void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�˳�����������
#else
        Application.Quit();
#endif
        /// <summary>
        /// ����д���� C# �е���������ָ�
        /// #if UNITY_EDITOR ��ʾ�����ǰ���뻷���� Unity �༭��������� UnityEditor.EditorApplication.isPlaying = false;
        /// ��һ�д��룬������� Application.Quit(); ��һ�д���
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
