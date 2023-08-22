using UnityEngine;

public class ItemPingPong : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� �̵� �ӵ�
    private Vector2 moveDirection = Vector2.one.normalized; // �밢�� �̵� ����

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection.Normalize(); // ������ ����ȭ
    }

    void FixedUpdate()
    {
        Vector2 movement = moveDirection * moveSpeed * Time.fixedDeltaTime;
        rb.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 normal = collision.contacts[0].normal;
            moveDirection = Vector2.Reflect(moveDirection, normal);
        }
    }
}
