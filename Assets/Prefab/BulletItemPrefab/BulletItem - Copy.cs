using UnityEngine;

public class BulletItem : MonoBehaviour
{
    private int bulletType; // 해당 아이템의 총알 종류

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어와 충돌했을 때
            BulletManager player = other.GetComponent<BulletManager>();
            
            if (player != null)
            {
                // 플레이어의 BulletManager에 총알 추가
                player.PickupBullet(bulletType, 1);
                
                // 아이템 제거
                Destroy(gameObject);
            }
        }
    }
}
