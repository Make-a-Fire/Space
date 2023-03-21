using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using Photon.Realtime;


public class MoveController : MonoBehaviour
{

    public static MoveController instance;

    //raycastのための変数
    private RaycastHit2D hit;
    public Vector2 direction;
    public Vector2 origin;
    public float anim_speed = 0.5f;
    public GameObject entercheck;

    [Header("フェード")] public FadeImage fade;
    private bool firstPush = false;
    private bool goNextScene = false;

    [SerializeField,Tooltip("移動スピード")]
    private int moveSpeed;

    [SerializeField]
    private Animator playerAnim;

    public Rigidbody2D rb;
    private Transform playerLocate;
    private float player_x;
    private float player_y;
    private float player_z;

    private Transform playerloc;
    public GameObject player2;


    private Vector2 begin_pos = Vector2.zero;
    private Vector2 now_pos = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        //キャラクターの初期位置
        player_x = PlayerPrefs.GetFloat("player_x", 0);
        player_y = PlayerPrefs.GetFloat("player_y", 0);
        player_z = PlayerPrefs.GetFloat("player_z", 0);
        playerLocate = GetComponent<Transform>();
        playerLocate.position= new Vector3(player_x,player_y,player_z);

        //アニメーション、プレイキャラクターの設定
        var player_character = PlayerPrefs.GetString("player_character", null);
        var player_character_anim = PlayerPrefs.GetString("player_character_anim", null);
        Addressables.LoadAssetAsync<Sprite>(player_character).Completed += sprite => {
            SpriteRenderer character = GetComponent<SpriteRenderer>();
            character.sprite = Instantiate(sprite.Result);
        };
        Addressables.LoadAssetAsync<RuntimeAnimatorController>(player_character_anim).Completed += RuntimeAnimatorController => {
            Animator anim = GetComponent<Animator>();
            anim.runtimeAnimatorController = Instantiate(RuntimeAnimatorController.Result);
        };

        if (instance == null)
        {
            instance = this;
        }
        entercheck.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        RayCaster();

    }


    private void PlayerMove()
    {

        //まうすでの入力
        if (Input.GetMouseButtonDown(0))
        {
            begin_pos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            now_pos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            begin_pos = Vector2.zero;
            now_pos = Vector2.zero;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                begin_pos = touch.position;
            }

            if (Input.touchCount > 0)
            {
                now_pos = touch.position;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                begin_pos = Vector2.zero;
                now_pos = Vector2.zero;
            }
        }
        //スマホでの入力
        

        
        



        


        Vector2 dist = now_pos - begin_pos;

        bool Moving = false;
        if (Mathf.Abs(dist.x) > Mathf.Abs(dist.y) || Input.GetAxisRaw("Horizontal") >0 || Input.GetAxisRaw("Horizontal") < 0)//横方向の入力の方が上方向よりも大きかったら
        {
            if (Input.GetAxisRaw("Horizontal") > 0 || dist.x > 0)
            {
                playerAnim.SetFloat("X", 1f);
                playerAnim.SetFloat("Y", 0f);
                playerAnim.SetFloat("Speed", anim_speed);
                direction = new Vector2(1, 0);

                Moving = true;
            }
            if (Input.GetAxisRaw("Horizontal") < 0 || dist.x < 0)
            {
                playerAnim.SetFloat("X", -1f);
                playerAnim.SetFloat("Y", 0f);
                playerAnim.SetFloat("Speed", anim_speed);
                direction = new Vector2(-1, 0);

                Moving = true;
            }
        }
        if(Mathf.Abs(dist.x) <= Mathf.Abs(dist.y) || Input.GetAxisRaw("Vertical") >0 || Input.GetAxisRaw("Vertical") < 0)
        {
            if (Input.GetAxisRaw("Vertical") > 0 || dist.y > 0)
            {
                playerAnim.SetFloat("X", 0f);
                playerAnim.SetFloat("Y", 1f);
                playerAnim.SetFloat("Speed", anim_speed);
                direction = new Vector2(0, 1);

                Moving = true;
            }
            if (Input.GetAxisRaw("Vertical") < 0 || dist.y < 0)
            {
                playerAnim.SetFloat("X", 0f);
                playerAnim.SetFloat("Y", -1f);
                playerAnim.SetFloat("Speed", anim_speed);
                direction = new Vector2(0, -1);

                Moving = true;
            }
        }
        if(Moving==false)
        {
            playerAnim.SetFloat("Speed", 0f);
            direction = new Vector2(0, 0);
        }

        rb.velocity = direction.normalized * moveSpeed;
    }


    private void RayCaster()
    {
        origin = this.transform.position;
        hit=Physics2D.Raycast(origin,direction,1.0f,LayerMask.GetMask("house"));
        Debug.DrawRay(origin, direction, Color.blue, 1.0f);
        if (hit.collider!=null)
        {
            //Debug.Log("入室しますか？");
            //Debug.Log(origin);
            HouseManager.instance.EnterHouse();
            //Debug.Log(direction);
        }
    }

    private string objName;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        objName = collision.gameObject.name;
        if (objName == "Door")
        {
            if (!firstPush)
            {
                player2 = GameObject.Find("Player");
                playerloc = player2.GetComponent<Transform>();
                Vector3 loc = playerloc.position;
                PlayerPrefs.SetFloat("player_x", loc.x);
                PlayerPrefs.SetFloat("player_y", loc.y);
                PlayerPrefs.SetFloat("player_z", loc.z);
                fade.StartFadeOut();
                firstPush = true;
                PlayerPrefs.SetString("nextScene", "library");
            }
        }
        if (objName == "Door2")
        {
            if (!firstPush)
            {
                player2 = GameObject.Find("Player");
                playerloc = player2.GetComponent<Transform>();
                Vector3 loc = playerloc.position;
                PlayerPrefs.SetFloat("player_x", loc.x);
                PlayerPrefs.SetFloat("player_y", loc.y);
                PlayerPrefs.SetFloat("player_z", loc.z);
                fade.StartFadeOut();
                firstPush = true;
                PlayerPrefs.SetString("nextScene", "house");
            }
        }
    }
}
