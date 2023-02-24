using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController_main : MonoBehaviour
{
    [Header("フェード")] public FadeImage fade;
    private bool firstPush = false;
    private bool goNextScene = false;
    public GameObject canvas_object;
    private bool check;
    public SaveData save;
    private string nextscene;

    void Start()
    {
        check = false;
        canvas_object.SetActive(check);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            check= !check;
            canvas_object.SetActive(check);
        }
        if (!goNextScene && fade.IsFadeOutComplete())
        {
            nextscene = PlayerPrefs.GetString("nextScene");
            SceneManager.LoadScene(nextscene);
            goNextScene = true;
        }
    }

    public void PushCharaChange()
    {
        if (!firstPush)
        {
            PlayerPrefs.SetString("nextScene", "ChangeCharacter");
            canvas_object.SetActive(false);
            save.Savedata();
            fade.StartFadeOut();
            firstPush = true;
            //PlayerPrefs.SetString("nextScene", "Main");
        }
    }
}
