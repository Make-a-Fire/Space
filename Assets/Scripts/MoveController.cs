using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public static MoveController instance;

    //raycastのための変数
    private RaycastHit2D hit;
    public Vector2 direction;
    public Vector2 origin;



    [SerializeField,Tooltip("移動スピード")]
    private int moveSpeed;

    [SerializeField]
    private Animator playerAnim;

    public Rigidbody2D rb;


    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        RayCaster();
    }

    private void PlayerMove()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerAnim.SetFloat("X", 1f);
            playerAnim.SetFloat("Y", 0f);
            direction = new Vector2(1, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerAnim.SetFloat("X", -1f);
            playerAnim.SetFloat("Y", 0f);
            direction = new Vector2(-1, 0);
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            playerAnim.SetFloat("X", 0f);
            playerAnim.SetFloat("Y", 1f);
            direction = new Vector2(0, 1);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            playerAnim.SetFloat("X", 0f);
            playerAnim.SetFloat("Y", -1f);
            direction = new Vector2(0, -1);
        }
        else
        {
            //if(playerAnim.GetFloat("X") == 1f && playerAnim.GetFloat("Y")==0f) ;
        }
    }


    private void RayCaster()
    {
        origin = this.transform.position;
        hit=Physics2D.Raycast(origin,direction,1.0f,LayerMask.GetMask("house"));
        Debug.DrawRay(origin, direction, Color.blue, 1.0f);
        if (hit.collider!=null)
        {
            Debug.Log("入室しますか？");
            Debug.Log(origin);
            HouseManager.instance.EnterHouse();
            //Debug.Log(direction);
        }
    }
}
