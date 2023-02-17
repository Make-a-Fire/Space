using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [Header("�t�F�[�h")] public FadeImage fade;
    private bool firstPush = false;
    private bool goNextScene = false;
    public void PressStart()
    {
        PlayerPrefs.SetString("player_character", "Assets/Sprites/Character/man01.png");
        PlayerPrefs.SetString("player_character_anim", "Assets/Animations/Player.controller");
        PlayerPrefs.SetInt("isLogin", 1);
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
            SceneManager.LoadScene("Main");
            goNextScene = true;
        }
    }
}
