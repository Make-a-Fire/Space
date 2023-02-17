using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private Transform playerLocate;
    public GameObject player;

    public void Savedata()
    {
        player = GameObject.Find("Player");
        playerLocate = player.GetComponent<Transform>();
        Vector3 loc= playerLocate.position;
        PlayerPrefs.SetFloat("player_x", loc.x);
        PlayerPrefs.SetFloat("player_y", loc.y);
        PlayerPrefs.SetFloat("player_z", loc.z);
    }
}
