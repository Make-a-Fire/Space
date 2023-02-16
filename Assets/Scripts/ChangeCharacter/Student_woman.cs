using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Student_woman : MonoBehaviour
{
    public void PressStart()
    {
        PlayerPrefs.SetString("player_character", "Assets/Sprites/Character/women.png");
        PlayerPrefs.SetString("player_character_anim", "Assets/Animations/student_w.overrideController");
        SceneManager.LoadScene("Main");
    }
}
