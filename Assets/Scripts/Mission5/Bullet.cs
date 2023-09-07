using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float bulletLifetime = 3.0f; // 총알의 수명 (예: 3초)

    private void Start()
    {
        // 총알이 발사되면 타이머를 시작하여 일정 시간 후에 자동으로 파괴됨
        Destroy(gameObject, bulletLifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 총알이 다른 콜라이더와 충돌했을 때 피격 처리를 수행
        if (other.CompareTag("Enemy"))
        {
            // 적 스크립트에서 체력을 깎는 등의 처리 수행
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount); // 예를 들어, 적의 TakeDamage 함수 호출
            }

            // 총알 파괴
            Destroy(gameObject);
        }
    }
}
