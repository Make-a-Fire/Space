using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButton_main : MonoBehaviour
{
    [Header("�t�F�[�h")] public FadeImage fade;
    private bool firstPush = false;
    private bool goNextScene = false;
    public void PushCharaChange()
    {
        if (!firstPush)
        {
            fade.StartFadeOut();
            firstPush = true;
        }
    }

    private void Update()
    {
        //�t�F�[�h�A�E�g�̊������Ď�
        if (!goNextScene && fade.IsFadeOutComplete())
        {
            SceneManager.LoadScene("ChangeCharacter");
            goNextScene = true;
        }
    }
}
