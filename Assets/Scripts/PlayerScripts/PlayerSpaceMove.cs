using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceMove : MonoBehaviour
{
    public float moveSpeed = 5f; // ���ּ��� ������ �ӵ�
    private Rigidbody2D rb;

    private BulletManager bulletManager;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        bulletManager = GetComponent<BulletManager>();

    }

    void Update()
    {
        // �÷��̾� �Է��� �޾� ���ּ��� �����̴� ������ �����մϴ�.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);

        rb.velocity = moveDirection.normalized * moveSpeed;


        if (Input.GetKeyDown(KeyCode.J))
        {
            bool shotSuccessful = bulletManager.ShootBullet();
            if (!shotSuccessful)
            {
                // 총알 발사 실패 처리 (예: 총알이 부족한 경우)
            }
        }
    }
}
