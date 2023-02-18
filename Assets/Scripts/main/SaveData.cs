using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    private Transform playerLocate;
    public GameObject player;

    public void Savedata()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        player = GameObject.Find("Player");
        playerLocate = player.GetComponent<Transform>();
        Vector3 loc= playerLocate.position;
        PlayerPrefs.SetString("nowScene", sceneName);
        PlayerPrefs.SetFloat("player_x", loc.x);
        PlayerPrefs.SetFloat("player_y", loc.y);
        PlayerPrefs.SetFloat("player_z", loc.z);
    }
}
