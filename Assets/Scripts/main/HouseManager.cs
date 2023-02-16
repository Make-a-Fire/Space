using System.Collections;
using System.Collections.Generic;

using System.Text;

using UnityEngine;
using UnityEngine.Tilemaps;

public class HouseManager : MonoBehaviour
{
    public static HouseManager instance;


    private int house_num=0;
    private float[] house_x = new float[100];
    private float[] house_y = new float[100];

    Vector2 upside = new Vector2(0, 1);

    Vector2 player_pos = new Vector2();
    //持てる家の数は100件まで


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    public void RegisterHouse(Tilemap tilemap)
    {
        var bound = tilemap.cellBounds;
        var spriteList = new List<Sprite>();

        //プレイヤーの座標を取得してint型に変換
        player_pos = MoveController.instance.origin;
        int x = (int)player_pos.x;
        int y = (int)player_pos.y;
        //

        for (int x_plus = -1; x_plus <= 1; x_plus++)
        {
            for(int y_plus=1;y_plus <= 2; y_plus++)
            {
                var tile=tilemap.GetTile<Tile>(new Vector3Int(x+x_plus,y+y_plus,0));
                if(tile!=null && !spriteList.Contains(tile.sprite)) {
                    spriteList.Add(tile.sprite);
                }
            }
        }

        var builder = new StringBuilder();

        for(int x_plus=-1; x_plus <= 1; x_plus++)
        {
            for(int y_plus=1; y_plus <= 2; y_plus++)
            {
                var tile = tilemap.GetTile<Tile>(new Vector3Int(x + x_plus, y + y_plus, 0));
                if (tile == null)
                {
                    builder.Append(".");
                }
                else
                {
                    var index=spriteList.IndexOf(tile.sprite);
                    builder.Append(index);
                }
            }
        }



        house_x[house_num] = 0;//要変更！！！！
        house_num++;

    }

    public void EnterHouse()
    {
        if (IsMyHouse())
        {
            SceneStateManager.instance.NextScene(SceneStateManager.SceneType.Room);
        }
        
        
    }


    //EnterHouse()用の関数
    private bool IsMyHouse()
    {
        if (MoveController.instance.direction != upside)//上向きで家に入るなら、
        {
            return false;
        }

        player_pos = MoveController.instance.origin;
        int x=(int)player_pos.x;
        int y=(int)player_pos.y;
        for(int i = 0; i < house_num; i++)
        {
            if(house_x[i]-0.5f<x || x < house_x[i] + 1.5f)
            {
                return true;
            }
        }
        return false;
    }

    

    
}
