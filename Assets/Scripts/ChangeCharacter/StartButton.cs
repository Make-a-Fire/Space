using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void PressStart()
    {
        PlayerPrefs.SetString("player_character", "Assets/Sprites/Character/man01.png");
        PlayerPrefs.SetString("player_character_anim", "Assets/Animations/Player.controller");
        SceneManager.LoadScene("Main");
    }
}
