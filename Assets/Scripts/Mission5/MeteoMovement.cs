using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    private Rigidbody2D rb; // Rigidbody2D 컴포넌트
    public float minSpeed = 2.0f; // 최소 속도
    public float maxSpeed = 5.0f; // 최대 속도

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 아래쪽 반원에서 랜덤한 방향으로 메테오 초기 이동
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        randomDirection.y = Mathf.Abs(randomDirection.y); // 아래 방향으로 이동

        // 랜덤한 속도 설정
        float speed = Random.Range(minSpeed, maxSpeed);

        // 초기 속도 설정
        rb.velocity = randomDirection * speed;
    }
}
