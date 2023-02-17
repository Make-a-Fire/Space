using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Student_man : MonoBehaviour
{
    [Header("フェード")] public FadeImage fade;
    private bool firstPush = false;
    private bool goNextScene = false;
    public void PressStart()
    {
        PlayerPrefs.SetString("player_character", "Assets/Sprites/Character/man.png");
        PlayerPrefs.SetString("player_character_anim", "Assets/Animations/student_m.overrideController");
        if (!firstPush)
        {
            fade.StartFadeOut();
            firstPush = true;
        }
    }
}
