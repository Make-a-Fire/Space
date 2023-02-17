using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [Header("フェード")] public FadeImage fade;
    private bool firstPush = false;
    private bool goNextScene = false;
    private int islogin;
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
            islogin = PlayerPrefs.GetInt("isLogin", 0);
            if (islogin == 0 )
            {
                SceneManager.LoadScene("ChangeCharacter");
            }
            else
            {
                SceneManager.LoadScene("Main");
            }     
            goNextScene= true;
        }
    }
}
