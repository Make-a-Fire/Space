using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    private RaycastHit2D hit;
    private Vector2 direction;
    private Vector2 origin;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.acceleration.x, Input.acceleration.y);
        
    }
}
