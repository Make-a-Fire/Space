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
            SceneManager.LoadScene("ChangeCharacter");
            goNextScene = true;
        }
    }

    public void PushCharaChange()
    {
        if (!firstPush)
        {
            canvas_object.SetActive(false);
            save.Savedata();
            fade.StartFadeOut();
            firstPush = true;
        }
    }
}
