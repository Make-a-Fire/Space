using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCollision : MonoBehaviour
{
    private Tilemap tilemap;

    private void Start()
    {
        // �^�C���}�b�v���擾
        tilemap = FindObjectOfType<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փ˂����I�u�W�F�N�g���v���C���[�̏ꍇ
        if (collision.gameObject.CompareTag("Player"))
        {
            // �Փ˂������W���擾
            Vector3 hitPosition = collision.GetContact(0).point;

            // �^�C���}�b�v��̍��W���擾
            Vector3Int tilePosition = tilemap.WorldToCell(hitPosition);

            Debug.Log("Tilemap position: " + tilePosition);
            tilemap.SetTile(tilePosition, null);
        }
    }
}