using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour
{

    public static SceneStateManager instance;

    public enum SceneType
    {
        Main,
        Room
    }
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void NextScene(SceneType nextSceneType)
    {
        SceneManager.LoadScene(nextSceneType.ToString());
    }
}
