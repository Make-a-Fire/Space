using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCollision : MonoBehaviour
{
    private Tilemap tilemap;

    private void Start()
    {
        // タイルマップを取得
        tilemap = FindObjectOfType<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトがプレイヤーの場合
        if (collision.gameObject.CompareTag("Player"))
        {
            // 衝突した座標を取得
            Vector3 hitPosition = collision.GetContact(0).point;

            // タイルマップ上の座標を取得
            Vector3Int tilePosition = tilemap.WorldToCell(hitPosition);

            Debug.Log("Tilemap position: " + tilePosition);
            tilemap.SetTile(tilePosition, null);
        }
    }
}