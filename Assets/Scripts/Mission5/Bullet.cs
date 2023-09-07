using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 10; // 총알의 데미지량

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 총알이 다른 콜라이더와 충돌했을 때 피격 처리를 수행
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount); // 적 스크립트의 TakeDamage 함수 호출
            }

            // 총알 파괴
            Destroy(gameObject);
        }
    }
}
