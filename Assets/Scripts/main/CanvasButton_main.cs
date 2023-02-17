using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButton_main : MonoBehaviour
{
    [Header("フェード")] public FadeImage fade;
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
        //フェードアウトの完了を監視
        if (!goNextScene && fade.IsFadeOutComplete())
        {
            SceneManager.LoadScene("ChangeCharacter");
            goNextScene = true;
        }
    }
}
