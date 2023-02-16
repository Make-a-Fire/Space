using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Student_man : MonoBehaviour
{
    public void PressStart()
    {
        PlayerPrefs.SetString("player_character", "Assets/Sprites/Character/man.png");
        PlayerPrefs.SetString("player_character_anim", "Assets/Animations/student_m.overrideController");
        SceneManager.LoadScene("Main");
    }
}
