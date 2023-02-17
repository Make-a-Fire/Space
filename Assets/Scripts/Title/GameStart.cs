using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [Header("フェード")] public FadeImage fade;
    private bool firstPush = false;
    private bool goNextScene = false;
    public void StartGame()
    {
        if (!firstPush)
        {
            fade.StartFadeOut();
            firstPush= true;
        }
    }

    private void Update()
    {
        //フェードアウトの完了を監視
        if (!goNextScene && fade.IsFadeOutComplete())
        {
            SceneManager.LoadScene("ChangeCharacter");
            goNextScene= true;
        }
    }
}
